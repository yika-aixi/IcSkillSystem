using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioPlayableOutput Value")]
    public partial class AudioPlayableOutputValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Audio.AudioPlayableOutput _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Audio.AudioPlayableOutput);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}