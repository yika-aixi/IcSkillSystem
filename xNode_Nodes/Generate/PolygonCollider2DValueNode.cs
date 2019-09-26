using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PolygonCollider2D Value")]
    public partial class PolygonCollider2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PolygonCollider2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PolygonCollider2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}