using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointAngleLimits2D Value")]
    public partial class JointAngleLimits2DValueNode:ValueNode<ValueInfo<UnityEngine.JointAngleLimits2D>>
    {
        [SerializeField]
        private UnityEngine.JointAngleLimits2D _value;
   
        private ValueInfo<UnityEngine.JointAngleLimits2D> _variableValue;
   
        protected override ValueInfo<UnityEngine.JointAngleLimits2D> GetTValue()
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