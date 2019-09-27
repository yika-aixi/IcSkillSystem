using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointSuspension2D Value")]
    public partial class JointSuspension2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.JointSuspension2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.JointSuspension2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}