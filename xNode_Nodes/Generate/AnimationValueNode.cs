using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/Animation Value")]
    public partial class AnimationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animation _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animation);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}