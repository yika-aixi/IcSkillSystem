using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioMixerSnapshot Value")]
    public partial class AudioMixerSnapshotValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Audio.AudioMixerSnapshot _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Audio.AudioMixerSnapshot);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}