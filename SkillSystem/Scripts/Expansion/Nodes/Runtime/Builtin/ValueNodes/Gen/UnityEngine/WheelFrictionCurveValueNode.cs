using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/WheelFrictionCurve Value")]
    public partial class WheelFrictionCurveValueNode:ValueNode<ValueInfo<UnityEngine.WheelFrictionCurve>>
    {
        [SerializeField]
        private UnityEngine.WheelFrictionCurve _value;
   
        private ValueInfo<UnityEngine.WheelFrictionCurve> _variableValue;
   
        protected override ValueInfo<UnityEngine.WheelFrictionCurve> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}