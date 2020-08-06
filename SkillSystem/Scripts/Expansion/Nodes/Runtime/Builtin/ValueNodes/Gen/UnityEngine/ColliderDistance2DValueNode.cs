using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ColliderDistance2D Value")]
    public partial class ColliderDistance2DValueNode:ValueNode<ValueInfo<UnityEngine.ColliderDistance2D>>
    {
        [SerializeField]
        private UnityEngine.ColliderDistance2D _value;
   
        private ValueInfo<UnityEngine.ColliderDistance2D> _variableValue = new ValueInfo<UnityEngine.ColliderDistance2D>();
   
        protected override ValueInfo<UnityEngine.ColliderDistance2D> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}