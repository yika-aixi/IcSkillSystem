using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AssetBundleModule/BuildCompression Value")]
    public partial class BuildCompressionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BuildCompression _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BuildCompression);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}