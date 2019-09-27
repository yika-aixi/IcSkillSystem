using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/NativeLeakDetectionMode Value")]
    public partial class NativeLeakDetectionModeValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Collections.NativeLeakDetectionMode _value;

        public override Type ValueType { get; } = typeof(Unity.Collections.NativeLeakDetectionMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}