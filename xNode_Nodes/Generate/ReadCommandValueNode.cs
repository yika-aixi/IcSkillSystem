using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReadCommand Value")]
    public partial class ReadCommandValueNode:ValueNode
    {
        [SerializeField]
        private Unity.IO.LowLevel.Unsafe.ReadCommand _value;

        public override Type ValueType { get; } = typeof(Unity.IO.LowLevel.Unsafe.ReadCommand);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}