using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RigidbodyType2D Value")]
    public partial class RigidbodyType2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RigidbodyType2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RigidbodyType2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}