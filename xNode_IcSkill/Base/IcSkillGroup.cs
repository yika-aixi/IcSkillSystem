//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:25
//Assembly-CSharp

using System;
using System.Collections.Generic;
using System.Linq;
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

        private List<Root> _roots = new List<Root>();

        /// <summary>
        /// 加载图
        /// </summary>
        /// <returns></returns>
        public void LoadGroup()
        {
            _init(this);
            
            List<RootNode> rootNodes = new List<RootNode>();
            
            foreach (var node in nodes)
            {
                if (node is RootNode rootNode)
                {
                    rootNodes.Add(rootNode);
                }
            }

            rootNodes = rootNodes.OrderBy(x => x.Priority).ToList();
            
            int count = 0;
            
            foreach (var rootNode in rootNodes)
            {
                RootNode = rootNode.GetDefaultOutputValue();

                if (_roots.Count - 1 <= count)
                {
                    _roots.Add(RootNode);
                }
                else
                {
                    _roots[count] = RootNode;
                }

                count++;
            }
        }

        /// <summary>
        /// Set Group variable
        /// </summary>
        /// <param name="map"></param>
        public void SetGroupVariable(ValueSDict map)
        {
            _varMap = map;
        }
        
        public void SetGroupVariable(Dictionary<string, object> variable)
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

        public object GetVariableValue(string key)
        {
            _varMap.TryGetValue(key, out var value);

            return value;
        }

        public void SetOrAddVariable(string key, object value)
        {
            if (_varMap.ContainsKey(key))
            {
                _varMap[key].SetValue(value);
            }
            else
            {
                var valueS = new ValueS();
                valueS.SetValue(value);
                _varMap.Add(key,valueS);
            }                        
        }

        public void ExecuteGroup()
        {
            if (_roots.Count == 0)
            {
                throw new InvalidOperationException("have not Load Group or Group no exist Root Node");
            }

            foreach (var root in _roots)
            {
                root.Start();
            }
        }

        public void StopGroup()
        {
            foreach (var root in _roots)
            {
                if (root.IsActive)
                {
                    root.Stop();
                }
            }
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