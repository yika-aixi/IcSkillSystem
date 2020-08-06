using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector2 Value")]
    public partial class Vector2ValueNode:ValueNode<ValueInfo<UnityEngine.Vector2>>
    {
        [SerializeField]
        private UnityEngine.Vector2 _value;
   
        private ValueInfo<UnityEngine.Vector2> _variableValue = new ValueInfo<UnityEngine.Vector2>();
   
        protected override ValueInfo<UnityEngine.Vector2> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}