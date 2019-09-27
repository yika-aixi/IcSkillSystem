using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReadStatus Value")]
    public partial class ReadStatusValueNode:ValueNode
    {
        [SerializeField]
        private Unity.IO.LowLevel.Unsafe.ReadStatus _value;

        public override Type ValueType { get; } = typeof(Unity.IO.LowLevel.Unsafe.ReadStatus);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}