using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/DirectorModule/PlayableDirector Value")]
    public partial class PlayableDirectorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.PlayableDirector _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.PlayableDirector);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}