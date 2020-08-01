using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationDrive Value")]
    public partial class ArticulationDriveValueNode:ValueNode<IcVariableArticulationDrive>
    {
        [SerializeField]
        private UnityEngine.ArticulationDrive _value;
   
        private IcVariableArticulationDrive _variableValue = new IcVariableArticulationDrive();
   
        protected override IcVariableArticulationDrive GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}