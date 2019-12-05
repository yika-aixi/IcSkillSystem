//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:25
//Assembly-CSharp

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NPBehave;
using UnityEngine;
using XNode;
using Node = NPBehave.Node;

namespace CabinIcarus.IcSkillSystem.xNode_Group
{
    [CreateAssetMenu(fileName = "New IcSkill Group",menuName = "CabinIcarus/IcSkillSystem/Group")]
    public class IcSkillGroup:NodeGraph
    {
        private GameObject _owner;

        [SerializeField]
        private ValueSDict _varMap = new ValueSDict();
            
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
                if (node is RootNode rootNode)
                {
                    RootNode = rootNode.GetDefaultOutputValue();

                    foreach (var item in (Dictionary<string, ValueS>)_varMap)
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
            
            RootNode = parent.RootNode;
            
            Node main = null;
            
            foreach (var node in nodes)
            {
                if (node is ChildGroupNode childGroupNode)
                {
                    main = childGroupNode.GetDefaultOutputValue();
                    break;
                }
            }

            return main;
        }

        public void SetBlackboardVariable(Dictionary<string, object> variable)
        {
            if (variable == null)
            {
                Debug.LogWarning("variable map is null");
                return;
            }
            _varMap.Clear();
            
            foreach (var valuePair in variable)
            {
                var value = new ValueS();
                value.SetValue(valuePair.Value);
                _varMap.Add(valuePair.Key,value);
            }
        }
        
        #region Serialize

#if UNITY_EDITOR
        public Dictionary<string, ValueS> VariableMap
        {
            get => _varMap;
            set => _varMap = (ValueSDict) value;
        }

        public const string VarMapFieldName = nameof(_varMap);
#endif

        #endregion
    }
}