using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationReducedSpace Value")]
    public partial class ArticulationReducedSpaceValueNode:ValueNode<IcVariableArticulationReducedSpace>
    {
        [SerializeField]
        private UnityEngine.ArticulationReducedSpace _value;
   
        private IcVariableArticulationReducedSpace _variableValue = new IcVariableArticulationReducedSpace();
   
        protected override IcVariableArticulationReducedSpace GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}