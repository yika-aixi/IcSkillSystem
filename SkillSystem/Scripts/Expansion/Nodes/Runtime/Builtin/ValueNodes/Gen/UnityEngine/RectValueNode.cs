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
            _variableValue = _value;
            return _variableValue;
        }
    }
}