using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/UInt32 Value")]
    public partial class UInt32ValueNode:ValueNode<IcVariableUInt32>
    {
        [SerializeField]
        private System.UInt32 _value;
   
        private IcVariableUInt32 _variableValue = new IcVariableUInt32();
   
        protected override IcVariableUInt32 GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableUInt32:ValueInfo<System.UInt32>
    {
    }
}