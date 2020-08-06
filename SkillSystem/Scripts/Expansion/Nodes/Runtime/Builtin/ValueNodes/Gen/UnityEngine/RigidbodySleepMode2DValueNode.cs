using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RigidbodySleepMode2D Value")]
    public partial class RigidbodySleepMode2DValueNode:ValueNode<ValueInfo<UnityEngine.RigidbodySleepMode2D>>
    {
        [SerializeField]
        private UnityEngine.RigidbodySleepMode2D _value;
   
        private ValueInfo<UnityEngine.RigidbodySleepMode2D> _variableValue = new ValueInfo<UnityEngine.RigidbodySleepMode2D>();
   
        protected override ValueInfo<UnityEngine.RigidbodySleepMode2D> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}