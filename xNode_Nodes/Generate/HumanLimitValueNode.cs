using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/HumanLimit Value")]
    public partial class HumanLimitValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HumanLimit _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HumanLimit);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}