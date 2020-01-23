using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/CabinIcarus/NPBehave/Type Value")]
    public partial class TypeValueNode:ValueNode<IcVariableType>
    {
        [SerializeField]
        private NPBehave.Blackboard.Type _value;
   
        private IcVariableType _variableValue = new IcVariableType();
   
        protected override IcVariableType GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}