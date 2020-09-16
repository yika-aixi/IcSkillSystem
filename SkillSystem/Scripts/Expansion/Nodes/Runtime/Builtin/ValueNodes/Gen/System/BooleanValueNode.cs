using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Boolean Value")]
    public partial class BooleanValueNode:ValueNode<ValueInfo<System.Boolean>>
    {
        [SerializeField]
        private System.Boolean _value;
   
        private ValueInfo<System.Boolean> _variableValue;
   
        protected override ValueInfo<System.Boolean> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}