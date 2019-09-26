using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SphereCollider Value")]
    public partial class SphereColliderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SphereCollider _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SphereCollider);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}