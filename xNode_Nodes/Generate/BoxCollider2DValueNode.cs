using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/BoxCollider2D Value")]
    public partial class BoxCollider2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BoxCollider2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BoxCollider2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}