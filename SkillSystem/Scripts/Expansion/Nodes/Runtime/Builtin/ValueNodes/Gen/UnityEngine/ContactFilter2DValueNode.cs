using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ContactFilter2D Value")]
    public partial class ContactFilter2DValueNode:ValueNode<ValueInfo<UnityEngine.ContactFilter2D>>
    {
        [SerializeField]
        private UnityEngine.ContactFilter2D _value;
   
        private ValueInfo<UnityEngine.ContactFilter2D> _variableValue = new ValueInfo<UnityEngine.ContactFilter2D>();
   
        protected override ValueInfo<UnityEngine.ContactFilter2D> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}