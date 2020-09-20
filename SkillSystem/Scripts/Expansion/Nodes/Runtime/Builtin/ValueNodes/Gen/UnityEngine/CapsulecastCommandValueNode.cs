using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CapsulecastCommand Value")]
    public partial class CapsulecastCommandValueNode:ValueNode<ValueInfo<UnityEngine.CapsulecastCommand>>
    {
        [SerializeField]
        private UnityEngine.CapsulecastCommand _value;
   
        private ValueInfo<UnityEngine.CapsulecastCommand> _variableValue;
   
        protected override ValueInfo<UnityEngine.CapsulecastCommand> GetTValue()
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