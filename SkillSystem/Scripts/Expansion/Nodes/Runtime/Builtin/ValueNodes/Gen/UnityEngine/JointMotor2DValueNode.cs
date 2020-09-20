using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointMotor2D Value")]
    public partial class JointMotor2DValueNode:ValueNode<ValueInfo<UnityEngine.JointMotor2D>>
    {
        [SerializeField]
        private UnityEngine.JointMotor2D _value;
   
        private ValueInfo<UnityEngine.JointMotor2D> _variableValue;
   
        protected override ValueInfo<UnityEngine.JointMotor2D> GetTValue()
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