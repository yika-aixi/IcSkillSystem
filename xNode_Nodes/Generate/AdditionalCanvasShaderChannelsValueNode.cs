using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIModule/AdditionalCanvasShaderChannels Value")]
    public partial class AdditionalCanvasShaderChannelsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AdditionalCanvasShaderChannels _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AdditionalCanvasShaderChannels);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}