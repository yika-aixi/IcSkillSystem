using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureEventState Value")]
    public partial class GestureEventStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureEventState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureEventState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}