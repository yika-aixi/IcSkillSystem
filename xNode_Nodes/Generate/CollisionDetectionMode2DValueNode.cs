using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CollisionDetectionMode2D Value")]
    public partial class CollisionDetectionMode2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CollisionDetectionMode2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CollisionDetectionMode2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}