using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CapsulecastCommand Value")]
    public partial class CapsulecastCommandValueNode:ValueNode<IcVariableCapsulecastCommand>
    {
        [SerializeField]
        private UnityEngine.CapsulecastCommand _value;
   
        private IcVariableCapsulecastCommand _variableValue = new IcVariableCapsulecastCommand();
   
        protected override IcVariableCapsulecastCommand GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}