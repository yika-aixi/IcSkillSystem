using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/MeshCollider Value")]
    public partial class MeshColliderValueNode:ValueNode<UnityEngine.MeshCollider>
    {
        [SerializeField]
        private UnityEngine.MeshCollider _value;
   
        protected override UnityEngine.MeshCollider GetTValue()
        {
            return _value;
        }
    }
}