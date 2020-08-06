using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/Collider Value")]
    public partial class ColliderValueNode:ValueNode<UnityEngine.Collider>
    {
        [SerializeField]
        private UnityEngine.Collider _value;
   
        protected override UnityEngine.Collider GetTValue()
        {
            return _value;
        }
    }
}