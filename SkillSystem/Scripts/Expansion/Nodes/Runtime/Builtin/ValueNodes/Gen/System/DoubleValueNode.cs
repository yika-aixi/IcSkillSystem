using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Double Value")]
    public partial class DoubleValueNode:ValueNode<ValueInfo<System.Double>>
    {
        [SerializeField]
        private System.Double _value;
   
        private ValueInfo<System.Double> _variableValue = new ValueInfo<System.Double>();
   
        protected override ValueInfo<System.Double> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}