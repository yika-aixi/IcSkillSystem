using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationJacobian Value")]
    public partial class ArticulationJacobianValueNode:ValueNode<ValueInfo<UnityEngine.ArticulationJacobian>>
    {
        [SerializeField]
        private UnityEngine.ArticulationJacobian _value;
   
        private ValueInfo<UnityEngine.ArticulationJacobian> _variableValue = new ValueInfo<UnityEngine.ArticulationJacobian>();
   
        protected override ValueInfo<UnityEngine.ArticulationJacobian> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}