using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioSpeakerMode Value")]
    public partial class AudioSpeakerModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioSpeakerMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioSpeakerMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}