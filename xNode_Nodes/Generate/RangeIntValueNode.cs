using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RangeInt Value")]
    public partial class RangeIntValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RangeInt _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RangeInt);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}