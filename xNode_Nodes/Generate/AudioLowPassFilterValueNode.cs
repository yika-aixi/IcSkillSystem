using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioLowPassFilter Value")]
    public partial class AudioLowPassFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioLowPassFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioLowPassFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}