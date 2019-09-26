using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioClip Value")]
    public partial class AudioClipValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioClip _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioClip);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}