using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CustomRenderTextureUpdateZoneSpace Value")]
    public partial class CustomRenderTextureUpdateZoneSpaceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CustomRenderTextureUpdateZoneSpace _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CustomRenderTextureUpdateZoneSpace);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}