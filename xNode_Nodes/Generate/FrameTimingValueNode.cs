using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FrameTiming Value")]
    public partial class FrameTimingValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FrameTiming _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FrameTiming);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}