using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VehiclesModule/WheelHit Value")]
    public partial class WheelHitValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WheelHit _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WheelHit);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}