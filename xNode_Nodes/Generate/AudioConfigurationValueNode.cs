using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioConfiguration Value")]
    public partial class AudioConfigurationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioConfiguration _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioConfiguration);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}