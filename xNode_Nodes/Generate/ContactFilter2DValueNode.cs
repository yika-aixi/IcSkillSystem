using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ContactFilter2D Value")]
    public partial class ContactFilter2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ContactFilter2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ContactFilter2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}