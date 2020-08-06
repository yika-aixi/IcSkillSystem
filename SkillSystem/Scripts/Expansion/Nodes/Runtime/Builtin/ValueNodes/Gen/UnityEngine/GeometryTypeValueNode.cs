using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/GeometryType Value")]
    public partial class GeometryTypeValueNode:ValueNode<ValueInfo<UnityEngine.CompositeCollider2D.GeometryType>>
    {
        [SerializeField]
        private UnityEngine.CompositeCollider2D.GeometryType _value;
   
        private ValueInfo<UnityEngine.CompositeCollider2D.GeometryType> _variableValue = new ValueInfo<UnityEngine.CompositeCollider2D.GeometryType>();
   
        protected override ValueInfo<UnityEngine.CompositeCollider2D.GeometryType> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}