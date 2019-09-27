using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/SpriteShapeModule/SpriteShapeParameters Value")]
    public partial class SpriteShapeParametersValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.U2D.SpriteShapeParameters _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.U2D.SpriteShapeParameters);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}