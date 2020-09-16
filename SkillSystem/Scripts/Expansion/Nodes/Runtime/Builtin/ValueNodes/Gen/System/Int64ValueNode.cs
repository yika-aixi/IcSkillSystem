using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Int64 Value")]
    public partial class Int64ValueNode:ValueNode<ValueInfo<System.Int64>>
    {
        [SerializeField]
        private System.Int64 _value;
   
        private ValueInfo<System.Int64> _variableValue;
   
        protected override ValueInfo<System.Int64> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}