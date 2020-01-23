using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/CabinIcarus/NPBehave/Request Value")]
    public partial class RequestValueNode:ValueNode<IcVariableRequest>
    {
        [SerializeField]
        private NPBehave.Action.Request _value;
   
        private IcVariableRequest _variableValue = new IcVariableRequest();
   
        protected override IcVariableRequest GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}