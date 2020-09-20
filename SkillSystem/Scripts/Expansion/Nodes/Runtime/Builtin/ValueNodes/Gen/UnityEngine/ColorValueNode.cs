using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Color Value")]
    public partial class ColorValueNode:ValueNode<ValueInfo<UnityEngine.Color>>
    {
        [SerializeField]
        private UnityEngine.Color _value;
   
        private ValueInfo<UnityEngine.Color> _variableValue;
   
        protected override ValueInfo<UnityEngine.Color> GetTValue()
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