using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioReverbPreset Value")]
    public partial class AudioReverbPresetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioReverbPreset _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioReverbPreset);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}