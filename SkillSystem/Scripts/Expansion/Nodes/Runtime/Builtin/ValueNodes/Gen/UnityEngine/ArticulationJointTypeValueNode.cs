using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationJointType Value")]
    public partial class ArticulationJointTypeValueNode:ValueNode<ValueInfo<UnityEngine.ArticulationJointType>>
    {
        [SerializeField]
        private UnityEngine.ArticulationJointType _value;
   
        private ValueInfo<UnityEngine.ArticulationJointType> _variableValue;
   
        protected override ValueInfo<UnityEngine.ArticulationJointType> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}