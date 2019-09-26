using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioBehaviour Value")]
    public partial class AudioBehaviourValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioBehaviour _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioBehaviour);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}