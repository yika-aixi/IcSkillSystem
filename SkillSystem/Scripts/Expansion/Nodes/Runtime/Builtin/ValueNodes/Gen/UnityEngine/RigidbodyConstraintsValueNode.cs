using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RigidbodyConstraints Value")]
    public partial class RigidbodyConstraintsValueNode:ValueNode<ValueInfo<UnityEngine.RigidbodyConstraints>>
    {
        [SerializeField]
        private UnityEngine.RigidbodyConstraints _value;
   
        private ValueInfo<UnityEngine.RigidbodyConstraints> _variableValue;
   
        protected override ValueInfo<UnityEngine.RigidbodyConstraints> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}