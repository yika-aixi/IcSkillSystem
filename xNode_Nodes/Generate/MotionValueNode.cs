using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/Motion Value")]
    public partial class MotionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Motion _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Motion);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}