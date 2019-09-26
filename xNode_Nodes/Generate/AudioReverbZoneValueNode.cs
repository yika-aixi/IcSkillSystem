using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioReverbZone Value")]
    public partial class AudioReverbZoneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioReverbZone _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioReverbZone);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}