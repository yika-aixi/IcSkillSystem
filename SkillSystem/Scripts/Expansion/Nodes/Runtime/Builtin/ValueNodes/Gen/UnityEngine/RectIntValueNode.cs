using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RectInt Value")]
    public partial class RectIntValueNode:ValueNode<ValueInfo<UnityEngine.RectInt>>
    {
        [SerializeField]
        private UnityEngine.RectInt _value;
   
        private ValueInfo<UnityEngine.RectInt> _variableValue;
   
        protected override ValueInfo<UnityEngine.RectInt> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}