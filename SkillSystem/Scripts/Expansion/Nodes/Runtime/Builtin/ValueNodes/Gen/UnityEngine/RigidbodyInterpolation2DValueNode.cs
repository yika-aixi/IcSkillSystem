using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RigidbodyInterpolation2D Value")]
    public partial class RigidbodyInterpolation2DValueNode:ValueNode<IcVariableRigidbodyInterpolation2D>
    {
        [SerializeField]
        private UnityEngine.RigidbodyInterpolation2D _value;
   
        private IcVariableRigidbodyInterpolation2D _variableValue = new IcVariableRigidbodyInterpolation2D();
   
        protected override IcVariableRigidbodyInterpolation2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}