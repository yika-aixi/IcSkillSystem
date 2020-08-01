using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CircleCollider2D Value")]
    public partial class CircleCollider2DValueNode:ValueNode<UnityEngine.CircleCollider2D>
    {
        [SerializeField]
        private UnityEngine.CircleCollider2D _value;
   
        protected override UnityEngine.CircleCollider2D GetTValue()
        {
            return _value;
        }
    }
}