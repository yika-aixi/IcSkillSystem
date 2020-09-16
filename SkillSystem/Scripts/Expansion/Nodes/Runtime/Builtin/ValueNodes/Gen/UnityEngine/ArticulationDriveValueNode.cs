using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationDrive Value")]
    public partial class ArticulationDriveValueNode:ValueNode<ValueInfo<UnityEngine.ArticulationDrive>>
    {
        [SerializeField]
        private UnityEngine.ArticulationDrive _value;
   
        private ValueInfo<UnityEngine.ArticulationDrive> _variableValue;
   
        protected override ValueInfo<UnityEngine.ArticulationDrive> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}