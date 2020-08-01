using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/WheelFrictionCurve Value")]
    public partial class WheelFrictionCurveValueNode:ValueNode<IcVariableWheelFrictionCurve>
    {
        [SerializeField]
        private UnityEngine.WheelFrictionCurve _value;
   
        private IcVariableWheelFrictionCurve _variableValue = new IcVariableWheelFrictionCurve();
   
        protected override IcVariableWheelFrictionCurve GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}