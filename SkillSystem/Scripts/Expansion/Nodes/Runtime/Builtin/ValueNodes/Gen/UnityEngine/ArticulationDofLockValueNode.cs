using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationDofLock Value")]
    public partial class ArticulationDofLockValueNode:ValueNode<ValueInfo<UnityEngine.ArticulationDofLock>>
    {
        [SerializeField]
        private UnityEngine.ArticulationDofLock _value;
   
        private ValueInfo<UnityEngine.ArticulationDofLock> _variableValue;
   
        protected override ValueInfo<UnityEngine.ArticulationDofLock> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}