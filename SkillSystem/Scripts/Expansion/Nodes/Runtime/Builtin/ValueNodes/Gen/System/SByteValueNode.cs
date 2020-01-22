using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/SByte Value")]
    public partial class SByteValueNode:ValueNode<IcVariableSByte>
    {
        [SerializeField]
        private System.SByte _value;
   
        private IcVariableSByte _variableValue = new IcVariableSByte();
   
        protected override IcVariableSByte GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableSByte:ValueInfo<System.SByte>
    {
    }
}