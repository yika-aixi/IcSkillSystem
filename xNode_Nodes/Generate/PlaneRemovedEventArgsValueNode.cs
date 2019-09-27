using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/PlaneRemovedEventArgs Value")]
    public partial class PlaneRemovedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.PlaneRemovedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.PlaneRemovedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}