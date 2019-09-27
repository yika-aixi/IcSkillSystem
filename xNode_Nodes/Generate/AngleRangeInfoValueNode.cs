using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/SpriteShapeModule/AngleRangeInfo Value")]
    public partial class AngleRangeInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.U2D.AngleRangeInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.U2D.AngleRangeInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}