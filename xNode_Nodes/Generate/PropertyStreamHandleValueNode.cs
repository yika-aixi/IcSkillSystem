using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/PropertyStreamHandle Value")]
    public partial class PropertyStreamHandleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.PropertyStreamHandle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.PropertyStreamHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}