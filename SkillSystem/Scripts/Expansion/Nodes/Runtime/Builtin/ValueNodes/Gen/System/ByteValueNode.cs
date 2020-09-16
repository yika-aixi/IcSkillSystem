using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Byte Value")]
    public partial class ByteValueNode:ValueNode<ValueInfo<System.Byte>>
    {
        [SerializeField]
        private System.Byte _value;
   
        private ValueInfo<System.Byte> _variableValue;
   
        protected override ValueInfo<System.Byte> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}