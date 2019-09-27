using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/AtomicSafetyHandle Value")]
    public partial class AtomicSafetyHandleValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Collections.LowLevel.Unsafe.AtomicSafetyHandle _value;

        public override Type ValueType { get; } = typeof(Unity.Collections.LowLevel.Unsafe.AtomicSafetyHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}