using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/CabinIcarus/NPBehave/Policy Value")]
    public partial class PolicyValueNode:ValueNode<IcVariablePolicy>
    {
        [SerializeField]
        private NPBehave.Parallel.Policy _value;
   
        private IcVariablePolicy _variableValue = new IcVariablePolicy();
   
        protected override IcVariablePolicy GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}