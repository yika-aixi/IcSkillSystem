using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationEvent Value")]
    public partial class AnimationEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimationEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimationEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}