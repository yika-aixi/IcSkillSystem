using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PolygonCollider2D Value")]
    public partial class PolygonCollider2DValueNode:ValueNode<UnityEngine.PolygonCollider2D>
    {
        [SerializeField]
        private UnityEngine.PolygonCollider2D _value;
   
        protected override UnityEngine.PolygonCollider2D GetTValue()
        {
            return _value;
        }
    }
}