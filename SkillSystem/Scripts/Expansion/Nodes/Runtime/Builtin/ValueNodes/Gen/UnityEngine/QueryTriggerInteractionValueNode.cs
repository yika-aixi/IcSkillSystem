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
            _variableValue.Value = _value;
            
            return _variableValue;
        }

        public override void OnStart()
        {
            base.OnStart();

            _variableValue = _value;
        }

        public override void OnStop()
        {
            base.OnStop();
            
            _variableValue.Release();

            _variableValue = null;
        }
    }
}