using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Single Value")]
    public partial class SingleValueNode:ValueNode<IcVariableSingle>
    {
        [SerializeField]
        private System.Single _value;
   
        private IcVariableSingle _variableValue = new IcVariableSingle();
   
        protected override IcVariableSingle GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}