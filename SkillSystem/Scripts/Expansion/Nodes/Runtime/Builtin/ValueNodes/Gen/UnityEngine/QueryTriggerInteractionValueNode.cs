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
   
        private ValueInfo<UnityEngine.QueryTriggerInteraction> _variableValue;
   
        protected override ValueInfo<UnityEngine.QueryTriggerInteraction> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}