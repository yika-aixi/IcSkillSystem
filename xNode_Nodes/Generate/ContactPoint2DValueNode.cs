using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ContactPoint2D Value")]
    public partial class ContactPoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ContactPoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ContactPoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}