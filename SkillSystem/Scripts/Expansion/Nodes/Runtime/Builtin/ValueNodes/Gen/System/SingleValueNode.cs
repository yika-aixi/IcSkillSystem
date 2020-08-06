using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Single Value")]
    public partial class SingleValueNode:ValueNode<ValueInfo<System.Single>>
    {
        [SerializeField]
        private System.Single _value;
   
        private ValueInfo<System.Single> _variableValue = new ValueInfo<System.Single>();
   
        protected override ValueInfo<System.Single> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}