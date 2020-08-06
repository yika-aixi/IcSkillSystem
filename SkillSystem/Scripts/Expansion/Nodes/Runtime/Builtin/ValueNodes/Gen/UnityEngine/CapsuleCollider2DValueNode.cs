using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CapsuleCollider2D Value")]
    public partial class CapsuleCollider2DValueNode:ValueNode<UnityEngine.CapsuleCollider2D>
    {
        [SerializeField]
        private UnityEngine.CapsuleCollider2D _value;
   
        protected override UnityEngine.CapsuleCollider2D GetTValue()
        {
            return _value;
        }
    }
}