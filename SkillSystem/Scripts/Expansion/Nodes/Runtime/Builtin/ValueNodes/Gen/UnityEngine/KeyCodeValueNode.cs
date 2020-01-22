using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

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
    
    [Serializable]
    public class IcVariableKeyCode:ValueInfo<UnityEngine.KeyCode>
    {
    }
}