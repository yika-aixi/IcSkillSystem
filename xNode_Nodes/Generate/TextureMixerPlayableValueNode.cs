using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TextureMixerPlayable Value")]
    public partial class TextureMixerPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Playables.TextureMixerPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Playables.TextureMixerPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}