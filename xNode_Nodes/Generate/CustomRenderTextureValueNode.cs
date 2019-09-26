using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CustomRenderTexture Value")]
    public partial class CustomRenderTextureValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CustomRenderTexture _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CustomRenderTexture);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}