using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CapsulecastCommand Value")]
    public partial class CapsulecastCommandValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CapsulecastCommand _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CapsulecastCommand);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}