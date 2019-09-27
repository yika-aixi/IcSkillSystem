using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SecondarySpriteTexture Value")]
    public partial class SecondarySpriteTextureValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SecondarySpriteTexture _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SecondarySpriteTexture);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}