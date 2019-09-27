using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlayableBinding Value")]
    public partial class PlayableBindingValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.PlayableBinding _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.PlayableBinding);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}