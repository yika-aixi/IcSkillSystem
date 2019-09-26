using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/PlayMode Value")]
    public partial class PlayModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PlayMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PlayMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}