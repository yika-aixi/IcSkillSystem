using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlayableOutputHandle Value")]
    public partial class PlayableOutputHandleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.PlayableOutputHandle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.PlayableOutputHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}