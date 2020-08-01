using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/SimulationMode2D Value")]
    public partial class SimulationMode2DValueNode:ValueNode<IcVariableSimulationMode2D>
    {
        [SerializeField]
        private UnityEngine.SimulationMode2D _value;
   
        private IcVariableSimulationMode2D _variableValue = new IcVariableSimulationMode2D();
   
        protected override IcVariableSimulationMode2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}