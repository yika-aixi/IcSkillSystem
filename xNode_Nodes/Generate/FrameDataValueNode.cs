using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FrameData Value")]
    public partial class FrameDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.FrameData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.FrameData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}