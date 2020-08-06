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
   
        private ValueInfo<UnityEngine.Color> _variableValue = new ValueInfo<UnityEngine.Color>();
   
        protected override ValueInfo<UnityEngine.Color> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}