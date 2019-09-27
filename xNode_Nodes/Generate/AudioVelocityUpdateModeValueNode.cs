using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioVelocityUpdateMode Value")]
    public partial class AudioVelocityUpdateModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioVelocityUpdateMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioVelocityUpdateMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}