using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioClipPlayable Value")]
    public partial class AudioClipPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Audio.AudioClipPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Audio.AudioClipPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}