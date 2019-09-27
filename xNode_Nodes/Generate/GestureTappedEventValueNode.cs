using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureTappedEvent Value")]
    public partial class GestureTappedEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureTappedEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureTappedEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}