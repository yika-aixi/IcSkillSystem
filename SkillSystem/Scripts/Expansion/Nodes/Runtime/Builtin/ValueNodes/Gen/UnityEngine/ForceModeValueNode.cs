using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ForceMode Value")]
    public partial class ForceModeValueNode:ValueNode<ValueInfo<UnityEngine.ForceMode>>
    {
        [SerializeField]
        private UnityEngine.ForceMode _value;
   
        private ValueInfo<UnityEngine.ForceMode> _variableValue;
   
        protected override ValueInfo<UnityEngine.ForceMode> GetTValue()
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