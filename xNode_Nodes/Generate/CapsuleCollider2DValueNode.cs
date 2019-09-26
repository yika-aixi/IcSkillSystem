using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CapsuleCollider2D Value")]
    public partial class CapsuleCollider2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CapsuleCollider2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CapsuleCollider2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}