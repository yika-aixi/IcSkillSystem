using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CapsuleCollider Value")]
    public partial class CapsuleColliderValueNode:ValueNode<UnityEngine.CapsuleCollider>
    {
        [SerializeField]
        private UnityEngine.CapsuleCollider _value;
   
        protected override UnityEngine.CapsuleCollider GetTValue()
        {
            return _value;
        }
    }
}