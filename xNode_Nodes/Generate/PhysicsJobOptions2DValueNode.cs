using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PhysicsJobOptions2D Value")]
    public partial class PhysicsJobOptions2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PhysicsJobOptions2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PhysicsJobOptions2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}