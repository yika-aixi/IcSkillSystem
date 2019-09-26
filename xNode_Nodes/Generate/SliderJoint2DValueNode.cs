using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/SliderJoint2D Value")]
    public partial class SliderJoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SliderJoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SliderJoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}