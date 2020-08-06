using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/MeshColliderCookingOptions Value")]
    public partial class MeshColliderCookingOptionsValueNode:ValueNode<ValueInfo<UnityEngine.MeshColliderCookingOptions>>
    {
        [SerializeField]
        private UnityEngine.MeshColliderCookingOptions _value;
   
        private ValueInfo<UnityEngine.MeshColliderCookingOptions> _variableValue = new ValueInfo<UnityEngine.MeshColliderCookingOptions>();
   
        protected override ValueInfo<UnityEngine.MeshColliderCookingOptions> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}