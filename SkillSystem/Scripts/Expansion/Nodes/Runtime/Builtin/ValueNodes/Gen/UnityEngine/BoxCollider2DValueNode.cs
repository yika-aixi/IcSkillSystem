using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/BoxCollider2D Value")]
    public partial class BoxCollider2DValueNode:ValueNode<UnityEngine.BoxCollider2D>
    {
        [SerializeField]
        private UnityEngine.BoxCollider2D _value;
   
        protected override UnityEngine.BoxCollider2D GetTValue()
        {
            return _value;
        }
    }
}