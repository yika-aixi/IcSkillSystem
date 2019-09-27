using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RigidbodyConstraints Value")]
    public partial class RigidbodyConstraintsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RigidbodyConstraints _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RigidbodyConstraints);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}