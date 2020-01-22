using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Char Value")]
    public partial class CharValueNode:ValueNode<IcVariableChar>
    {
        [SerializeField]
        private System.Char _value;
   
        private IcVariableChar _variableValue = new IcVariableChar();
   
        protected override IcVariableChar GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableChar:ValueInfo<System.Char>
    {
    }
}