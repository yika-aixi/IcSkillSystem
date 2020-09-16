using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector4 Value")]
    public partial class Vector4ValueNode:ValueNode<ValueInfo<UnityEngine.Vector4>>
    {
        [SerializeField]
        private UnityEngine.Vector4 _value;
   
        private ValueInfo<UnityEngine.Vector4> _variableValue;
   
        protected override ValueInfo<UnityEngine.Vector4> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}