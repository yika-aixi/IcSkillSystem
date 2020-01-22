using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Int16 Value")]
    public partial class Int16ValueNode:ValueNode<IcVariableInt16>
    {
        [SerializeField]
        private System.Int16 _value;
   
        private IcVariableInt16 _variableValue = new IcVariableInt16();
   
        protected override IcVariableInt16 GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableInt16:ValueInfo<System.Int16>
    {
    }
}