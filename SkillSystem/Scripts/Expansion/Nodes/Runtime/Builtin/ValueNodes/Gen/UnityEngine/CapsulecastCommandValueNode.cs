using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CapsulecastCommand Value")]
    public partial class CapsulecastCommandValueNode:ValueNode<ValueInfo<UnityEngine.CapsulecastCommand>>
    {
        [SerializeField]
        private UnityEngine.CapsulecastCommand _value;
   
        private ValueInfo<UnityEngine.CapsulecastCommand> _variableValue;
   
        protected override ValueInfo<UnityEngine.CapsulecastCommand> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}