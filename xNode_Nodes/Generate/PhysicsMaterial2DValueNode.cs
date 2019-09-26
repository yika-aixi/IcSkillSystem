using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PhysicsMaterial2D Value")]
    public partial class PhysicsMaterial2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PhysicsMaterial2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PhysicsMaterial2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}