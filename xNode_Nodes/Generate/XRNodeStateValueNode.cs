using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/XRNodeState Value")]
    public partial class XRNodeStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.XRNodeState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.XRNodeState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}