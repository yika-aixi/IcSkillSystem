using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CompositeCollider2D Value")]
    public partial class CompositeCollider2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CompositeCollider2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CompositeCollider2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}