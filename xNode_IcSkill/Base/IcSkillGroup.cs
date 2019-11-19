//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:25
//Assembly-CSharp

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NPBehave;
using UnityEngine;
using XNode;
using Node = NPBehave.Node;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.xNode_Group
{
    [CreateAssetMenu(fileName = "New IcSkill Group",menuName = "CabinIcarus/IcSkillSystem/Group")]
    public class IcSkillGroup:NodeGraph,ISerializationCallbackReceiver
    {
        private GameObject _owner;
        private Dictionary<string, ValueS> _varMap = new Dictionary<string, ValueS>();
            
        public GameObject Owner
        {
            get
            {
                if (!_owner)
                {
                    throw new NullReferenceException("no set Owner");
                }

                return _owner;
            }

            set
            {
                _owner = value;

                foreach (var node in nodes)
                {
                    if (node.GetType() == typeof(GetChildGroupNode))
                    {
                        var subNode = (GetChildGroupNode) node;
                        subNode.GetGroup().Owner = _owner;
                    }
                }
            }
        }
        
        public Root RootNode { get; private set; }

        /// <summary>
        /// 开始,返回Node
        /// </summary>
        /// <returns></returns>
        public Root Start()
        {
            _init(this);

            foreach (var node in nodes)
            {
                if (node.GetType() == typeof(RootNode))
                {
                    RootNode = (Root) node.GetValue(null);

                    foreach (var item in _varMap)
                    {
                        RootNode.Blackboard.Set(item.Key,item.Value.GetValue());  
                    }

                    break;
                }
            }

            return RootNode;
        }

        private void _init(IcSkillGroup group)
        {
            foreach (var node in nodes)
            {
                if (node is IIcSkillSystemNode skillNode)
                {
                    skillNode.SkillGroup = group;
                }
            }
        }

        /// <summary>
        /// 获取子图,返回Node
        /// </summary>
        /// <returns></returns>
        public Node GetChildGroupNode(IcSkillGroup parent)
        {
            _init(parent);
//            RootNode = parent.RootNode;
            
            Node main = null;
            
            foreach (var node in nodes)
            {
                if (node.GetType() == typeof(ChildGroupNode))
                {
                    main = (Node) node.GetValue(null);
                    break;
                }
            }

            return main;
        }

        #region Serialize
        
        [Serializable]
        public class ValueS
        {
            [SerializeField]
            private bool _isUnity;
            
            public bool IsUnity => _isUnity;

            [SerializeField]
            private string ValueTypeAqName;

            [SerializeField]
            private string _valueStr;

            private object _value;

            [SerializeField]
            private Object _uValue;
            public Object UValue => _uValue;

            private Type _type;
            
            public Type ValueType
            {
                get
                {
                    if (_type == null && !string.IsNullOrWhiteSpace(ValueTypeAqName))
                    {
                        _type = Type.GetType(ValueTypeAqName);
                    }
                
                    return _type;
                } 

                set
                {
                    _isUnity = typeof(Object).IsAssignableFrom(value);

                    _type = value;

                    ValueTypeAqName = value != null ? value.AssemblyQualifiedName : string.Empty;
                }
            }

            public void SetValue(object value)
            {
                if (_isUnity)
                {
                    _uValue = (Object) value;
                    return;
                }
                
                _valueStr = SerializationUtil.ToString(value);

            }

            public object GetValue()
            {
                if (_isUnity)
                {
                    return UValue;
                }
                
                return SerializationUtil.ToValue(_valueStr,ValueType);
            }
        }

#if UNITY_EDITOR
        public const string KeysName = nameof(_keys);
        public const string ValuesName = nameof(_values);
        public Dictionary<string, ValueS> VariableMap
        {
            get => _varMap;
            set => _varMap = value;
        }
#endif
        
        [SerializeField]
        List<string> _keys = new List<string>();
        
        [SerializeField]
        List<ValueS> _values = new List<ValueS>();
        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();
            
            foreach (var keyValuePair in _varMap)
            {
                _keys.Add(keyValuePair.Key);

                var value = keyValuePair.Value;

                _values.Add(value);
            }
        }

        public void OnAfterDeserialize()
        {
            _varMap.Clear();

            for (var i = 0; i < _keys.Count; i++)
            {
                var key = _keys[i];
                var value = _values[i];
                
                _varMap.Add(key,value);
            }
        }

        #endregion
    }
}