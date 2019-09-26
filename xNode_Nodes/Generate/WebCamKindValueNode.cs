using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/WebCamKind Value")]
    public partial class WebCamKindValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WebCamKind _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WebCamKind);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}