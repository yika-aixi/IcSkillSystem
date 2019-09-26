using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CollisionFlags Value")]
    public partial class CollisionFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CollisionFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CollisionFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}