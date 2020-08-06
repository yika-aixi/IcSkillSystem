using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CollisionFlags Value")]
    public partial class CollisionFlagsValueNode:ValueNode<ValueInfo<UnityEngine.CollisionFlags>>
    {
        [SerializeField]
        private UnityEngine.CollisionFlags _value;
   
        private ValueInfo<UnityEngine.CollisionFlags> _variableValue = new ValueInfo<UnityEngine.CollisionFlags>();
   
        protected override ValueInfo<UnityEngine.CollisionFlags> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}