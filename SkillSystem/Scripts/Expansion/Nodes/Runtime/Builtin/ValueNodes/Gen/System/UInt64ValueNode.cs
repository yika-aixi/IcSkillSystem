using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/UInt64 Value")]
    public partial class UInt64ValueNode:ValueNode<IcVariableUInt64>
    {
        [SerializeField]
        private System.UInt64 _value;
   
        private IcVariableUInt64 _variableValue = new IcVariableUInt64();
   
        protected override IcVariableUInt64 GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableUInt64:ValueInfo<System.UInt64>
    {
    }
}