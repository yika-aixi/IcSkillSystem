using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ControllerColliderHit Value")]
    public partial class ControllerColliderHitValueNode:ValueNode<UnityEngine.ControllerColliderHit>
    {
        [SerializeField]
        private UnityEngine.ControllerColliderHit _value;
   
        protected override UnityEngine.ControllerColliderHit GetTValue()
        {
            return _value;
        }
    }
}