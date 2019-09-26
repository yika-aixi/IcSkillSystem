using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/Collider2D Value")]
    public partial class Collider2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Collider2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Collider2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}