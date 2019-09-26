using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/SpriteShapeModule/SpriteShapeRenderer Value")]
    public partial class SpriteShapeRendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.U2D.SpriteShapeRenderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.U2D.SpriteShapeRenderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}