using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioMixerPlayable Value")]
    public partial class AudioMixerPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Audio.AudioMixerPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Audio.AudioMixerPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}