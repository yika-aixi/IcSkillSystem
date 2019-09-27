using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/WheelFrictionCurve Value")]
    public partial class WheelFrictionCurveValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WheelFrictionCurve _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WheelFrictionCurve);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}