using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PhysicsScene2D Value")]
    public partial class PhysicsScene2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PhysicsScene2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PhysicsScene2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}