using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/CabinIcarus/NPBehave/Result Value")]
    public partial class ResultValueNode:ValueNode<IcVariableResult>
    {
        [SerializeField]
        private NPBehave.Action.Result _value;
   
        private IcVariableResult _variableValue = new IcVariableResult();
   
        protected override IcVariableResult GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}