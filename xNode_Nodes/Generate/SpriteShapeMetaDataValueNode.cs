using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/SpriteShapeModule/SpriteShapeMetaData Value")]
    public partial class SpriteShapeMetaDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.U2D.SpriteShapeMetaData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.U2D.SpriteShapeMetaData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}