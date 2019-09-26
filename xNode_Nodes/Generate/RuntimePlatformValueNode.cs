using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RuntimePlatform Value")]
    public partial class RuntimePlatformValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RuntimePlatform _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RuntimePlatform);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}