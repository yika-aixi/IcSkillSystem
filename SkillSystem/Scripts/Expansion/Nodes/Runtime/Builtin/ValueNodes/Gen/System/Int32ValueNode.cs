using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Int32 Value")]
    public partial class Int32ValueNode:ValueNode<IcVariableInt32>
    {
        [SerializeField]
        private System.Int32 _value;
   
        private IcVariableInt32 _variableValue = new IcVariableInt32();
   
        protected override IcVariableInt32 GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableInt32:ValueInfo<System.Int32>
    {
    }
}