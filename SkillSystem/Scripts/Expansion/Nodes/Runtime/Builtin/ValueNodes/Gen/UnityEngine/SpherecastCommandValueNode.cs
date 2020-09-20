using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SpherecastCommand Value")]
    public partial class SpherecastCommandValueNode:ValueNode<ValueInfo<UnityEngine.SpherecastCommand>>
    {
        [SerializeField]
        private UnityEngine.SpherecastCommand _value;
   
        private ValueInfo<UnityEngine.SpherecastCommand> _variableValue;
   
        protected override ValueInfo<UnityEngine.SpherecastCommand> GetTValue()
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