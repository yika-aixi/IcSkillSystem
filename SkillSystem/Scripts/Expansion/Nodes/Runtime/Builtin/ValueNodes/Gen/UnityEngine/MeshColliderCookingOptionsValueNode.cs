using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/MeshColliderCookingOptions Value")]
    public partial class MeshColliderCookingOptionsValueNode:ValueNode<IcVariableMeshColliderCookingOptions>
    {
        [SerializeField]
        private UnityEngine.MeshColliderCookingOptions _value;
   
        private IcVariableMeshColliderCookingOptions _variableValue = new IcVariableMeshColliderCookingOptions();
   
        protected override IcVariableMeshColliderCookingOptions GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}