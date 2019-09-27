using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationScriptPlayable Value")]
    public partial class AnimationScriptPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.AnimationScriptPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.AnimationScriptPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}