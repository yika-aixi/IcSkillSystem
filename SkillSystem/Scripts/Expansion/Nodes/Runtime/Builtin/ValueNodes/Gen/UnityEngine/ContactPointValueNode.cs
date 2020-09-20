using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ContactPoint Value")]
    public partial class ContactPointValueNode:ValueNode<ValueInfo<UnityEngine.ContactPoint>>
    {
        [SerializeField]
        private UnityEngine.ContactPoint _value;
   
        private ValueInfo<UnityEngine.ContactPoint> _variableValue;
   
        protected override ValueInfo<UnityEngine.ContactPoint> GetTValue()
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