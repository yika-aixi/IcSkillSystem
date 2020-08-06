using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationReducedSpace Value")]
    public partial class ArticulationReducedSpaceValueNode:ValueNode<ValueInfo<UnityEngine.ArticulationReducedSpace>>
    {
        [SerializeField]
        private UnityEngine.ArticulationReducedSpace _value;
   
        private ValueInfo<UnityEngine.ArticulationReducedSpace> _variableValue = new ValueInfo<UnityEngine.ArticulationReducedSpace>();
   
        protected override ValueInfo<UnityEngine.ArticulationReducedSpace> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}