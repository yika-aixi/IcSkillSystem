using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioRolloffMode Value")]
    public partial class AudioRolloffModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioRolloffMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioRolloffMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}