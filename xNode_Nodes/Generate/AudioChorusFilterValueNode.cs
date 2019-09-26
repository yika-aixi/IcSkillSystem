using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioChorusFilter Value")]
    public partial class AudioChorusFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioChorusFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioChorusFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}