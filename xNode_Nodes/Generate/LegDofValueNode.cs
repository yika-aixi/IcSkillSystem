using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/LegDof Value")]
    public partial class LegDofValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LegDof _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LegDof);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}