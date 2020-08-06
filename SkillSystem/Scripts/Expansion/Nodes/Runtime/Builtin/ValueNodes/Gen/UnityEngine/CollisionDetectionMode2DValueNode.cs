using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CollisionDetectionMode2D Value")]
    public partial class CollisionDetectionMode2DValueNode:ValueNode<ValueInfo<UnityEngine.CollisionDetectionMode2D>>
    {
        [SerializeField]
        private UnityEngine.CollisionDetectionMode2D _value;
   
        private ValueInfo<UnityEngine.CollisionDetectionMode2D> _variableValue = new ValueInfo<UnityEngine.CollisionDetectionMode2D>();
   
        protected override ValueInfo<UnityEngine.CollisionDetectionMode2D> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}