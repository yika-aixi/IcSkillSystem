using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ConfigurableJointMotion Value")]
    public partial class ConfigurableJointMotionValueNode:ValueNode<ValueInfo<UnityEngine.ConfigurableJointMotion>>
    {
        [SerializeField]
        private UnityEngine.ConfigurableJointMotion _value;
   
        private ValueInfo<UnityEngine.ConfigurableJointMotion> _variableValue;
   
        protected override ValueInfo<UnityEngine.ConfigurableJointMotion> GetTValue()
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