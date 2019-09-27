using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointAngleLimits2D Value")]
    public partial class JointAngleLimits2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.JointAngleLimits2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.JointAngleLimits2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}