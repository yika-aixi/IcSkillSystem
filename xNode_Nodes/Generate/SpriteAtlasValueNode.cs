using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpriteAtlas Value")]
    public partial class SpriteAtlasValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.U2D.SpriteAtlas _value;

        public override Type ValueType { get; } = typeof(UnityEngine.U2D.SpriteAtlas);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}