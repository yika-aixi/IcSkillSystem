using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/HandFinger Value")]
    public partial class HandFingerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.HandFinger _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.HandFinger);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}