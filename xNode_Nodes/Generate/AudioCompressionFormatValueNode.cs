using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioCompressionFormat Value")]
    public partial class AudioCompressionFormatValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioCompressionFormat _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioCompressionFormat);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}