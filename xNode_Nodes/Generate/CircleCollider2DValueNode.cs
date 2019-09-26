using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CircleCollider2D Value")]
    public partial class CircleCollider2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CircleCollider2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CircleCollider2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}