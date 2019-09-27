using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioMixerUpdateMode Value")]
    public partial class AudioMixerUpdateModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Audio.AudioMixerUpdateMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Audio.AudioMixerUpdateMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}