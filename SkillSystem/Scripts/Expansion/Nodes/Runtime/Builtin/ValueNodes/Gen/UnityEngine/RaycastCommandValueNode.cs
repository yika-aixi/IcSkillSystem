using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RaycastCommand Value")]
    public partial class RaycastCommandValueNode:ValueNode<ValueInfo<UnityEngine.RaycastCommand>>
    {
        [SerializeField]
        private UnityEngine.RaycastCommand _value;
   
        private ValueInfo<UnityEngine.RaycastCommand> _variableValue;
   
        protected override ValueInfo<UnityEngine.RaycastCommand> GetTValue()
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