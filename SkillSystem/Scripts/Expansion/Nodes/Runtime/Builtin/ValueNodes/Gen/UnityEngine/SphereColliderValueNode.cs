using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SphereCollider Value")]
    public partial class SphereColliderValueNode:ValueNode<UnityEngine.SphereCollider>
    {
        [SerializeField]
        private UnityEngine.SphereCollider _value;
   
        protected override UnityEngine.SphereCollider GetTValue()
        {
            return _value;
        }
    }
}