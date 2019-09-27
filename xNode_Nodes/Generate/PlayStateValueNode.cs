using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlayState Value")]
    public partial class PlayStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.PlayState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.PlayState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}