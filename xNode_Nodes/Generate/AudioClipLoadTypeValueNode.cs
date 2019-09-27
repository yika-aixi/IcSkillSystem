using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioClipLoadType Value")]
    public partial class AudioClipLoadTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioClipLoadType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioClipLoadType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}