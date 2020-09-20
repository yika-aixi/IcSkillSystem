using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CollisionDetectionMode2D Value")]
    public partial class CollisionDetectionMode2DValueNode:ValueNode<ValueInfo<UnityEngine.CollisionDetectionMode2D>>
    {
        [SerializeField]
        private UnityEngine.CollisionDetectionMode2D _value;
   
        private ValueInfo<UnityEngine.CollisionDetectionMode2D> _variableValue;
   
        protected override ValueInfo<UnityEngine.CollisionDetectionMode2D> GetTValue()
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