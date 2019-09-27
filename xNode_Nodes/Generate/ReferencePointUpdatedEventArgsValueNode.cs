using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/ReferencePointUpdatedEventArgs Value")]
    public partial class ReferencePointUpdatedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.ReferencePointUpdatedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.ReferencePointUpdatedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}