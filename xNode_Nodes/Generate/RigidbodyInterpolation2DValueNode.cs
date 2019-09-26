using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RigidbodyInterpolation2D Value")]
    public partial class RigidbodyInterpolation2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RigidbodyInterpolation2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RigidbodyInterpolation2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}