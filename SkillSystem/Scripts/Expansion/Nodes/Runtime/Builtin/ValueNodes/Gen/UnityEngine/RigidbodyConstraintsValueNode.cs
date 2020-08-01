using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RigidbodyConstraints Value")]
    public partial class RigidbodyConstraintsValueNode:ValueNode<IcVariableRigidbodyConstraints>
    {
        [SerializeField]
        private UnityEngine.RigidbodyConstraints _value;
   
        private IcVariableRigidbodyConstraints _variableValue = new IcVariableRigidbodyConstraints();
   
        protected override IcVariableRigidbodyConstraints GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}