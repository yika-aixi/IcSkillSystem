using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/Collider Value")]
    public partial class ColliderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Collider _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Collider);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}