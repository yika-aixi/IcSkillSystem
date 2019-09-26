using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/CustomStreamPropertyType Value")]
    public partial class CustomStreamPropertyTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.CustomStreamPropertyType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.CustomStreamPropertyType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}