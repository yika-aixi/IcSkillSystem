using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/FingerDof Value")]
    public partial class FingerDofValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FingerDof _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FingerDof);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}