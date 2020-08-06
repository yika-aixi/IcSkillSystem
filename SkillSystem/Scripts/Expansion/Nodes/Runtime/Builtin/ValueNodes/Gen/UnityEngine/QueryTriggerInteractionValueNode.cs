using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/QueryTriggerInteraction Value")]
    public partial class QueryTriggerInteractionValueNode:ValueNode<ValueInfo<UnityEngine.QueryTriggerInteraction>>
    {
        [SerializeField]
        private UnityEngine.QueryTriggerInteraction _value;
   
        private ValueInfo<UnityEngine.QueryTriggerInteraction> _variableValue = new ValueInfo<UnityEngine.QueryTriggerInteraction>();
   
        protected override ValueInfo<UnityEngine.QueryTriggerInteraction> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}