using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioHighPassFilter Value")]
    public partial class AudioHighPassFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioHighPassFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioHighPassFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}