using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/TransformSceneHandle Value")]
    public partial class TransformSceneHandleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.TransformSceneHandle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.TransformSceneHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}