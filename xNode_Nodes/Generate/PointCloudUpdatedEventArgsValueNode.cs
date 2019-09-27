using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/PointCloudUpdatedEventArgs Value")]
    public partial class PointCloudUpdatedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.PointCloudUpdatedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.PointCloudUpdatedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}