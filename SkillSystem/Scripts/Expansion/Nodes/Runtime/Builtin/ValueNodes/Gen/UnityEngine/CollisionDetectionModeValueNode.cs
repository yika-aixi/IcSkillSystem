using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CollisionDetectionMode Value")]
    public partial class CollisionDetectionModeValueNode:ValueNode<ValueInfo<UnityEngine.CollisionDetectionMode>>
    {
        [SerializeField]
        private UnityEngine.CollisionDetectionMode _value;
   
        private ValueInfo<UnityEngine.CollisionDetectionMode> _variableValue;
   
        protected override ValueInfo<UnityEngine.CollisionDetectionMode> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}