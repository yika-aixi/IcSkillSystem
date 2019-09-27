using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RigidbodyInterpolation Value")]
    public partial class RigidbodyInterpolationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RigidbodyInterpolation _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RigidbodyInterpolation);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}