using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureNavigationEvent Value")]
    public partial class GestureNavigationEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureNavigationEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureNavigationEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}