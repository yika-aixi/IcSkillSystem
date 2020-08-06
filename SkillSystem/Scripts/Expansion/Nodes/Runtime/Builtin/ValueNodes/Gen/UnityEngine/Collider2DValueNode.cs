using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/Collider2D Value")]
    public partial class Collider2DValueNode:ValueNode<UnityEngine.Collider2D>
    {
        [SerializeField]
        private UnityEngine.Collider2D _value;
   
        protected override UnityEngine.Collider2D GetTValue()
        {
            return _value;
        }
    }
}