using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/WeightedMode Value")]
    public partial class WeightedModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WeightedMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WeightedMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}