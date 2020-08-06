using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ForceMode2D Value")]
    public partial class ForceMode2DValueNode:ValueNode<ValueInfo<UnityEngine.ForceMode2D>>
    {
        [SerializeField]
        private UnityEngine.ForceMode2D _value;
   
        private ValueInfo<UnityEngine.ForceMode2D> _variableValue = new ValueInfo<UnityEngine.ForceMode2D>();
   
        protected override ValueInfo<UnityEngine.ForceMode2D> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}