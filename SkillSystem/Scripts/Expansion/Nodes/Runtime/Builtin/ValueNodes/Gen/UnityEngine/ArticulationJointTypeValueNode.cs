using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationJointType Value")]
    public partial class ArticulationJointTypeValueNode:ValueNode<IcVariableArticulationJointType>
    {
        [SerializeField]
        private UnityEngine.ArticulationJointType _value;
   
        private IcVariableArticulationJointType _variableValue = new IcVariableArticulationJointType();
   
        protected override IcVariableArticulationJointType GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}