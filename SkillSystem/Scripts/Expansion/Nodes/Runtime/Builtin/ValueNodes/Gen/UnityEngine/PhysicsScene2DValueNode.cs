using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PhysicsScene2D Value")]
    public partial class PhysicsScene2DValueNode:ValueNode<ValueInfo<UnityEngine.PhysicsScene2D>>
    {
        [SerializeField]
        private UnityEngine.PhysicsScene2D _value;
   
        private ValueInfo<UnityEngine.PhysicsScene2D> _variableValue;
   
        protected override ValueInfo<UnityEngine.PhysicsScene2D> GetTValue()
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