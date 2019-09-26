using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioMixerGroup Value")]
    public partial class AudioMixerGroupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Audio.AudioMixerGroup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Audio.AudioMixerGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}