using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CompositeCollider2D Value")]
    public partial class CompositeCollider2DValueNode:ValueNode<UnityEngine.CompositeCollider2D>
    {
        [SerializeField]
        private UnityEngine.CompositeCollider2D _value;
   
        protected override UnityEngine.CompositeCollider2D GetTValue()
        {
            return _value;
        }
    }
}