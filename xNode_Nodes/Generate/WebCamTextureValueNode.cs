using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/WebCamTexture Value")]
    public partial class WebCamTextureValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WebCamTexture _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WebCamTexture);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}