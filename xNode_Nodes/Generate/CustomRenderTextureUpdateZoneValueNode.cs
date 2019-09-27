using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CustomRenderTextureUpdateZone Value")]
    public partial class CustomRenderTextureUpdateZoneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CustomRenderTextureUpdateZone _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CustomRenderTextureUpdateZone);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}