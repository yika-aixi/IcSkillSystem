using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PhysicsUpdateBehaviour2D Value")]
    public partial class PhysicsUpdateBehaviour2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PhysicsUpdateBehaviour2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PhysicsUpdateBehaviour2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}