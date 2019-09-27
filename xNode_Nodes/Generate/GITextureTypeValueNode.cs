using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GITextureType Value")]
    public partial class GITextureTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngineInternal.GITextureType _value;

        public override Type ValueType { get; } = typeof(UnityEngineInternal.GITextureType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}