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
            _variableValue = _value;
            return _variableValue;
        }
    }
}