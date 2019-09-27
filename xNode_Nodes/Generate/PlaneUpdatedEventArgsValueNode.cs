using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/PlaneUpdatedEventArgs Value")]
    public partial class PlaneUpdatedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.PlaneUpdatedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.PlaneUpdatedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}