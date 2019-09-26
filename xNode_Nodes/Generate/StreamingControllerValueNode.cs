using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/StreamingModule/StreamingController Value")]
    public partial class StreamingControllerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.StreamingController _value;

        public override Type ValueType { get; } = typeof(UnityEngine.StreamingController);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}