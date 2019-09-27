using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Playable Value")]
    public partial class PlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.Playable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.Playable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}