using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CustomRenderTextureUpdateMode Value")]
    public partial class CustomRenderTextureUpdateModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CustomRenderTextureUpdateMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CustomRenderTextureUpdateMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}