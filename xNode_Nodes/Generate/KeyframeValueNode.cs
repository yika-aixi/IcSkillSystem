using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Keyframe Value")]
    public partial class KeyframeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Keyframe _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Keyframe);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}