using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/RawImage Value")]
    public partial class RawImageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.RawImage _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.RawImage);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}