using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Byte Value")]
    public partial class ByteValueNode:ValueNode<IcVariableByte>
    {
        [SerializeField]
        private System.Byte _value;
   
        private IcVariableByte _variableValue = new IcVariableByte();
   
        protected override IcVariableByte GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableByte:ValueInfo<System.Byte>
    {
    }
}