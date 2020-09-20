using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector2 Value")]
    public partial class Vector2ValueNode:ValueNode<ValueInfo<UnityEngine.Vector2>>
    {
        [SerializeField]
        private UnityEngine.Vector2 _value;
   
        private ValueInfo<UnityEngine.Vector2> _variableValue;
   
        protected override ValueInfo<UnityEngine.Vector2> GetTValue()
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