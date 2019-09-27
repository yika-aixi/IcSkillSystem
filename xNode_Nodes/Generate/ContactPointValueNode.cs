using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ContactPoint Value")]
    public partial class ContactPointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ContactPoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ContactPoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}