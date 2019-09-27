using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlayableOutput Value")]
    public partial class PlayableOutputValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.PlayableOutput _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.PlayableOutput);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}