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
    public class IcSkillGraph:NodeGraph
    {
        private static RoodNodeComparer _roodNodeComparer = new RoodNodeComparer();
        private GameObject _owner;
        private Guid _id;
        public Guid ID => _id;

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
        
        private List<RootNode> _rootNodes = new List<RootNode>();

        private int _rootCount;
        
        /// <summary>
        /// 加载图
        /// </summary>
        /// <returns></returns>
        public void LoadGroup()
        {
            _init(this);
            
            foreach (var node in nodes)
            {
                if (node is RootNode rootNode)
                {
                    rootNode.GetDefaultOutputValue();
                    _rootNodes.Add(rootNode);
                }
            }
            
            _rootNodes.Sort(_roodNodeComparer);

            _rootCount = _rootNodes.Count;
        }

        List<string> _keys;

        public IcSkillGraph()
        {
            _keys = _varMap.Keys.ToList();
            _id = Guid.NewGuid();
        }
        
        /// <summary>
        /// Set Group variable
        /// </summary>
        /// <param name="map"></param>
        public void SetGroupVariable(ValueSDict map)
        {
            _varMap = map;

            var count = _keys.Count;
            
            for (var i = 0; i < count; i++)
            {
                var key = _keys[i];
            
                var result = map.TryGetValue(key, out var value);

                if (result)
                {
                    _varMap[key] = value;
                }
            }
        }

        public ValueInfo<T> GetVariableValue<T>(string key)
        {
            return GetVariableValue(key)?.GetValue<T>();
        }

        public ValueS GetVariableValue(string key)
        {
            _varMap.TryGetValue(key, out var value);

            return value;
        }

        public void SetOrAddVariable<T>(string key, T value)
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
                _keys.Add(key);
            }      
        }
        
        public void SetOrAddVariable<T>(string key, ValueInfo<T> value)
        {
            if (_varMap.ContainsKey(key))
            {
                _varMap[key].SetValueInfo(value);
            }
            else
            {
                var valueS = new ValueS();
                valueS.SetValueInfo(value);
                _varMap.Add(key,valueS);
                _keys.Add(key);
            }      
        }

        public Root FirstRoot { get; private set; }

        /// <summary>
        /// Start Group 
        /// </summary>
        /// <returns>first Root</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Root ExecuteGroup()
        {
            if (_rootNodes.Count == 0)
            {
                throw new InvalidOperationException("have not Load Group or Group no exist Root Node");
            }
            
            for (var i = 0; i < _rootCount; i++)
            {
                var root = _rootNodes[i];
                
                // To be safe, need to prevent the first root node from non starting automatically because of manual data modification, and need to start it.
                if (root.AutoStart || i == 0)
                {
                     root.OutValue.Start();

                     if (FirstRoot == null)
                     {
                         FirstRoot = root.OutValue;
                     }
                }
            }

            return FirstRoot;
        }

        public void StopGroup()
        {
            for (var i = 0; i < _rootCount; i++)
            {
                var rootNode = _rootNodes[i];
                
                var root = rootNode.OutValue;
                
                if (root != null && root.IsActive)
                {
                    root.Stop();
                }
            }
        }

        /// <summary>
        /// group exist Active Root
        /// </summary>
        /// <returns></returns>
        public bool IsActive()
        {
            for (var i = 0; i < _rootCount; i++)
            {
                var rootNode = _rootNodes[i];
                
                var root = rootNode.OutValue;

                if (root.IsActive)
                {
                    return true;
                }
            }

            return false;
        }

        private void _init(IcSkillGraph graph)
        {
            for (var index = 0; index < nodes.Count; index++)
            {
                var node = nodes[index];
                if (node is IIcSkillSystemNode skillNode)
                {
                    skillNode.SkillGraph = graph;
                    skillNode.OnInit();
                }
            }
        }

        /// <summary>
        /// 获取子图,返回Node
        /// </summary>
        /// <returns></returns>
        public Node GetChildGroupNode(IcSkillGraph parent)
        {
            _init(parent);
            
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