using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Double Value")]
    public partial class DoubleValueNode:ValueNode<IcVariableDouble>
    {
        [SerializeField]
        private System.Double _value;
   
        private IcVariableDouble _variableValue = new IcVariableDouble();
   
        protected override IcVariableDouble GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableDouble:ValueInfo<System.Double>
    {
    }
}