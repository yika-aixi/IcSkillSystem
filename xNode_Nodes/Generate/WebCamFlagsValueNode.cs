using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/WebCamFlags Value")]
    public partial class WebCamFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WebCamFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WebCamFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}