using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ConstantForce Value")]
    public partial class ConstantForceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ConstantForce _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ConstantForce);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}