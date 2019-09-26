using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/EdgeCollider2D Value")]
    public partial class EdgeCollider2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EdgeCollider2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EdgeCollider2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}