using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Int64 Value")]
    public partial class Int64ValueNode:ValueNode<IcVariableInt64>
    {
        [SerializeField]
        private System.Int64 _value;
   
        private IcVariableInt64 _variableValue = new IcVariableInt64();
   
        protected override IcVariableInt64 GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}