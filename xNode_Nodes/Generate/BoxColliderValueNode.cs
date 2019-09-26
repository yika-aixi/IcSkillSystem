using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/BoxCollider Value")]
    public partial class BoxColliderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BoxCollider _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BoxCollider);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}