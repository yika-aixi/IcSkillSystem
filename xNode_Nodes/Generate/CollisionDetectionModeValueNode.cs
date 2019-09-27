using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CollisionDetectionMode Value")]
    public partial class CollisionDetectionModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CollisionDetectionMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CollisionDetectionMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}