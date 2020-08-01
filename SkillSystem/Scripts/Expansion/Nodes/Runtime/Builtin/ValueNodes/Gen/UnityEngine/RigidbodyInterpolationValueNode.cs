using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RigidbodyInterpolation Value")]
    public partial class RigidbodyInterpolationValueNode:ValueNode<IcVariableRigidbodyInterpolation>
    {
        [SerializeField]
        private UnityEngine.RigidbodyInterpolation _value;
   
        private IcVariableRigidbodyInterpolation _variableValue = new IcVariableRigidbodyInterpolation();
   
        protected override IcVariableRigidbodyInterpolation GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}