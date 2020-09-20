using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Rect Value")]
    public partial class RectValueNode:ValueNode<ValueInfo<UnityEngine.Rect>>
    {
        [SerializeField]
        private UnityEngine.Rect _value;
   
        private ValueInfo<UnityEngine.Rect> _variableValue;
   
        protected override ValueInfo<UnityEngine.Rect> GetTValue()
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