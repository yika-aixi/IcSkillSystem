using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/CabinIcarus/NPBehave/Stops Value")]
    public partial class StopsValueNode:ValueNode<IcVariableStops>
    {
        [SerializeField]
        private NPBehave.Stops _value;
   
        private IcVariableStops _variableValue = new IcVariableStops();
   
        protected override IcVariableStops GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}