using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/MeshColliderCookingOptions Value")]
    public partial class MeshColliderCookingOptionsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MeshColliderCookingOptions _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MeshColliderCookingOptions);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}