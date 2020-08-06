using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/GenerationType Value")]
    public partial class GenerationTypeValueNode:ValueNode<ValueInfo<UnityEngine.CompositeCollider2D.GenerationType>>
    {
        [SerializeField]
        private UnityEngine.CompositeCollider2D.GenerationType _value;
   
        private ValueInfo<UnityEngine.CompositeCollider2D.GenerationType> _variableValue = new ValueInfo<UnityEngine.CompositeCollider2D.GenerationType>();
   
        protected override ValueInfo<UnityEngine.CompositeCollider2D.GenerationType> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}