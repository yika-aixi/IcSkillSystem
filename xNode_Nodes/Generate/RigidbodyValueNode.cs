using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/Rigidbody Value")]
    public partial class RigidbodyValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rigidbody _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rigidbody);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}