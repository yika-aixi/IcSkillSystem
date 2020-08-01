using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ContactPoint Value")]
    public partial class ContactPointValueNode:ValueNode<IcVariableContactPoint>
    {
        [SerializeField]
        private UnityEngine.ContactPoint _value;
   
        private IcVariableContactPoint _variableValue = new IcVariableContactPoint();
   
        protected override IcVariableContactPoint GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}