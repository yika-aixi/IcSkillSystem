using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/EdgeCollider2D Value")]
    public partial class EdgeCollider2DValueNode:ValueNode<UnityEngine.EdgeCollider2D>
    {
        [SerializeField]
        private UnityEngine.EdgeCollider2D _value;
   
        protected override UnityEngine.EdgeCollider2D GetTValue()
        {
            return _value;
        }
    }
}