using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioSource Value")]
    public partial class AudioSourceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioSource _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioSource);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}