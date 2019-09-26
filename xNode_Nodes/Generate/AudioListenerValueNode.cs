using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioListener Value")]
    public partial class AudioListenerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioListener _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioListener);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}