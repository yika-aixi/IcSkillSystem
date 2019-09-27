using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/ArmDof Value")]
    public partial class ArmDofValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ArmDof _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ArmDof);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}