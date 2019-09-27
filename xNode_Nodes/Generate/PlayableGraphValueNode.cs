using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlayableGraph Value")]
    public partial class PlayableGraphValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.PlayableGraph _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.PlayableGraph);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}