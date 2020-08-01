using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/QueryTriggerInteraction Value")]
    public partial class QueryTriggerInteractionValueNode:ValueNode<IcVariableQueryTriggerInteraction>
    {
        [SerializeField]
        private UnityEngine.QueryTriggerInteraction _value;
   
        private IcVariableQueryTriggerInteraction _variableValue = new IcVariableQueryTriggerInteraction();
   
        protected override IcVariableQueryTriggerInteraction GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}