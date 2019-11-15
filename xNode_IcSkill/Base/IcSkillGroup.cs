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

namespace CabinIcarus.IcSkillSystem.xNode_Group
{
    [CreateAssetMenu(fileName = "New IcSkill Group",menuName = "CabinIcarus/IcSkillSystem/Group")]
    public class IcSkillGroup:NodeGraph,ISerializationCallbackReceiver
    {
        private GameObject _owner;
        private Dictionary<string, object> _varMap = new Dictionary<string, object>();
            
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

        [SerializeField]
        private List<string> _kyes = new List<string>();

        [SerializeField]
        private List<object> _values = new List<object>();
        public void OnBeforeSerialize()
        {
            _kyes.Clear();
            _values.Clear();
            _kyes.AddRange(_varMap.Keys);
            _values.AddRange(_varMap.Values);
        }

        public void OnAfterDeserialize()
        {
            _varMap.Clear();
            
            for (var i = 0; i < _kyes.Count; i++)
            {
                _varMap.Add(_kyes[i], _values[i]);
            }
        }
    }
}