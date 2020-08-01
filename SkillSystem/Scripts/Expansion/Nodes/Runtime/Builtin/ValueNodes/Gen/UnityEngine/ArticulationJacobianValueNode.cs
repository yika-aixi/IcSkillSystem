using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationJacobian Value")]
    public partial class ArticulationJacobianValueNode:ValueNode<IcVariableArticulationJacobian>
    {
        [SerializeField]
        private UnityEngine.ArticulationJacobian _value;
   
        private IcVariableArticulationJacobian _variableValue = new IcVariableArticulationJacobian();
   
        protected override IcVariableArticulationJacobian GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}