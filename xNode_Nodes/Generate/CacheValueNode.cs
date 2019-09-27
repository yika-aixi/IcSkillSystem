using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Cache Value")]
    public partial class CacheValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Cache _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Cache);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}