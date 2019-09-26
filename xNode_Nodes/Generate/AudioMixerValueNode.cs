using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioMixer Value")]
    public partial class AudioMixerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Audio.AudioMixer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Audio.AudioMixer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}