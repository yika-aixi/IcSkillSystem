using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Color32 Value")]
    public partial class Color32ValueNode:ValueNode<ValueInfo<UnityEngine.Color32>>
    {
        [SerializeField]
        private UnityEngine.Color32 _value;
   
        private ValueInfo<UnityEngine.Color32> _variableValue;
   
        protected override ValueInfo<UnityEngine.Color32> GetTValue()
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