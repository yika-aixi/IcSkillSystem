using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/HingeJoint2D Value")]
    public partial class HingeJoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HingeJoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HingeJoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}