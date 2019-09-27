using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/SpriteShapeModule/SpriteShapeSegment Value")]
    public partial class SpriteShapeSegmentValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.U2D.SpriteShapeSegment _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.U2D.SpriteShapeSegment);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}