using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SoftJointLimit Value")]
    public partial class SoftJointLimitValueNode:ValueNode<ValueInfo<UnityEngine.SoftJointLimit>>
    {
        [SerializeField]
        private UnityEngine.SoftJointLimit _value;
   
        private ValueInfo<UnityEngine.SoftJointLimit> _variableValue;
   
        protected override ValueInfo<UnityEngine.SoftJointLimit> GetTValue()
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