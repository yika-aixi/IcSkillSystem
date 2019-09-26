using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VehiclesModule/WheelCollider Value")]
    public partial class WheelColliderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WheelCollider _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WheelCollider);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}