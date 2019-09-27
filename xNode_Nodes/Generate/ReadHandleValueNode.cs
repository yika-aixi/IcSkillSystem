using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReadHandle Value")]
    public partial class ReadHandleValueNode:ValueNode
    {
        [SerializeField]
        private Unity.IO.LowLevel.Unsafe.ReadHandle _value;

        public override Type ValueType { get; } = typeof(Unity.IO.LowLevel.Unsafe.ReadHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}