using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/BoxCollider Value")]
    public partial class BoxColliderValueNode:ValueNode<UnityEngine.BoxCollider>
    {
        [SerializeField]
        private UnityEngine.BoxCollider _value;
   
        protected override UnityEngine.BoxCollider GetTValue()
        {
            return _value;
        }
    }
}