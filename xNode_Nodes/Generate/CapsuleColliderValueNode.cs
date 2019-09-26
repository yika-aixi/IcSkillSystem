using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CapsuleCollider Value")]
    public partial class CapsuleColliderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CapsuleCollider _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CapsuleCollider);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}