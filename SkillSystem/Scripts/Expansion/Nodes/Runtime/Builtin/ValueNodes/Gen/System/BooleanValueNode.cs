using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Boolean Value")]
    public partial class BooleanValueNode:ValueNode<IcVariableBoolean>
    {
        [SerializeField]
        private System.Boolean _value;
   
        private IcVariableBoolean _variableValue = new IcVariableBoolean();
   
        protected override IcVariableBoolean GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}