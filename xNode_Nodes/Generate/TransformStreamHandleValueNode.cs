using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/TransformStreamHandle Value")]
    public partial class TransformStreamHandleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.TransformStreamHandle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.TransformStreamHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}