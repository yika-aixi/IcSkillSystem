using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RaycastHit Value")]
    public partial class RaycastHitValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RaycastHit _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RaycastHit);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}