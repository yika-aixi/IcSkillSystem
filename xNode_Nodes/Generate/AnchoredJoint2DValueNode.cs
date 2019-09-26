using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/AnchoredJoint2D Value")]
    public partial class AnchoredJoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnchoredJoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnchoredJoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}