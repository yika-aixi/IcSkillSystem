using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RelativeJoint2D Value")]
    public partial class RelativeJoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RelativeJoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RelativeJoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}