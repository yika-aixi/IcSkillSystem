using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/Rigidbody2D Value")]
    public partial class Rigidbody2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rigidbody2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rigidbody2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}