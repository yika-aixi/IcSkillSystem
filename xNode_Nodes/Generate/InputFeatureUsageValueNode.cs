using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/InputFeatureUsage Value")]
    public partial class InputFeatureUsageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.InputFeatureUsage _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.InputFeatureUsage);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}