using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/EffectorForceMode2D Value")]
    public partial class EffectorForceMode2DValueNode:ValueNode<ValueInfo<UnityEngine.EffectorForceMode2D>>
    {
        [SerializeField]
        private UnityEngine.EffectorForceMode2D _value;
   
        private ValueInfo<UnityEngine.EffectorForceMode2D> _variableValue = new ValueInfo<UnityEngine.EffectorForceMode2D>();
   
        protected override ValueInfo<UnityEngine.EffectorForceMode2D> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}