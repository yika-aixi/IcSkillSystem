using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/UInt16 Value")]
    public partial class UInt16ValueNode:ValueNode<IcVariableUInt16>
    {
        [SerializeField]
        private System.UInt16 _value;
   
        private IcVariableUInt16 _variableValue = new IcVariableUInt16();
   
        protected override IcVariableUInt16 GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableUInt16:ValueInfo<System.UInt16>
    {
    }
}