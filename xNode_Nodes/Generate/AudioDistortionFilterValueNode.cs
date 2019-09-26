using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioDistortionFilter Value")]
    public partial class AudioDistortionFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioDistortionFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioDistortionFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}