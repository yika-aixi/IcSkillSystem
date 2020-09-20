using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointMotor Value")]
    public partial class JointMotorValueNode:ValueNode<ValueInfo<UnityEngine.JointMotor>>
    {
        [SerializeField]
        private UnityEngine.JointMotor _value;
   
        private ValueInfo<UnityEngine.JointMotor> _variableValue;
   
        protected override ValueInfo<UnityEngine.JointMotor> GetTValue()
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