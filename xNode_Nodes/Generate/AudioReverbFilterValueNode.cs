using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioReverbFilter Value")]
    public partial class AudioReverbFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioReverbFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioReverbFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}