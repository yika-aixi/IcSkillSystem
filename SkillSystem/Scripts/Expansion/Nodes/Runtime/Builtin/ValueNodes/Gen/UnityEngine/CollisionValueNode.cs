using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/Collision Value")]
    public partial class CollisionValueNode:ValueNode<UnityEngine.Collision>
    {
        [SerializeField]
        private UnityEngine.Collision _value;
   
        protected override UnityEngine.Collision GetTValue()
        {
            return _value;
        }
    }
}