using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/XRNode Value")]
    public partial class XRNodeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.XRNode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.XRNode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}