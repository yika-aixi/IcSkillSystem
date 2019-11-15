//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:25
//Assembly-CSharp

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using NPBehave;
using UnityEngine;
using XNode;
using Node = NPBehave.Node;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.xNode_Group
{
    public struct ValueS
    {
        public string ValueTypeAqName;

        public object Value;
    }
    
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

            set => _owner = value;
        }

        /// <summary>
        /// 开始,返回Node
        /// </summary>
        /// <returns></returns>
        public Root Start()
        {
            Root rootNode = null;
            foreach (var node in nodes)
            {
                if (node.GetType() == typeof(RootNode))
                {
                    rootNode = (Root) node.GetValue(null);
                    break;
                }
            }

            return rootNode;
        }
        
        /// <summary>
        /// 获取子图,返回Node
        /// </summary>
        /// <returns></returns>
        public Node GetChildGroupNode()
        {
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

        [SerializeField] 
        private string _serializeStr;
        
#if UNITY_EDITOR
        public const string SerializeFieldName = nameof(_serializeStr);

        public Dictionary<string, ValueS> VariableMap
        {
            get => _varMap;
            set => _varMap = value;
        }
#endif
        List<string> _keys = new List<string>();
        List<ValueS> _objectValues = new List<ValueS>();
        List<Object> _unityValues = new List<Object>();
        
        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _objectValues.Clear();
            _unityValues.Clear();
            
            foreach (var keyValuePair in _varMap)
            {
                _keys.Add(keyValuePair.Key);

                var value = keyValuePair.Value;

               if (value.Value is Object uObj)
               {
                   _unityValues.Add(uObj);
               }
               else
               {
                   _objectValues.Add(value);
               }
            }
        }

        public void OnAfterDeserialize()
        {
            _varMap.Clear();
        }

        #endregion

    }
}