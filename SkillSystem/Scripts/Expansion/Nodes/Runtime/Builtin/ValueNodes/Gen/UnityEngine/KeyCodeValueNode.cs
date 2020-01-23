using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/KeyCode Value")]
    public partial class KeyCodeValueNode:ValueNode<IcVariableKeyCode>
    {
        [SerializeField]
        private UnityEngine.KeyCode _value;
   
        private IcVariableKeyCode _variableValue = new IcVariableKeyCode();
   
        protected override IcVariableKeyCode GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}