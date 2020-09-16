using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RigidbodyInterpolation Value")]
    public partial class RigidbodyInterpolationValueNode:ValueNode<ValueInfo<UnityEngine.RigidbodyInterpolation>>
    {
        [SerializeField]
        private UnityEngine.RigidbodyInterpolation _value;
   
        private ValueInfo<UnityEngine.RigidbodyInterpolation> _variableValue;
   
        protected override ValueInfo<UnityEngine.RigidbodyInterpolation> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}