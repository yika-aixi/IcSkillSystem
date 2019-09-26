using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ConstantForce2D Value")]
    public partial class ConstantForce2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ConstantForce2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ConstantForce2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}