using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlayableHandle Value")]
    public partial class PlayableHandleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.PlayableHandle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.PlayableHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}