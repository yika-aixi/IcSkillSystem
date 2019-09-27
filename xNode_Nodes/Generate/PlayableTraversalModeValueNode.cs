using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlayableTraversalMode Value")]
    public partial class PlayableTraversalModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.PlayableTraversalMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.PlayableTraversalMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}