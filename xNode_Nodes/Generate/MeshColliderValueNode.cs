using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/MeshCollider Value")]
    public partial class MeshColliderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MeshCollider _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MeshCollider);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}