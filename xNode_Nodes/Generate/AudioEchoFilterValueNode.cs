using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioEchoFilter Value")]
    public partial class AudioEchoFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioEchoFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioEchoFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}