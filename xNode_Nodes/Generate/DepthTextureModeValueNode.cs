using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DepthTextureMode Value")]
    public partial class DepthTextureModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.DepthTextureMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.DepthTextureMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}