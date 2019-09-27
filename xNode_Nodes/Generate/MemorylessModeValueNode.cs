using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MemorylessMode Value")]
    public partial class MemorylessModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngineInternal.MemorylessMode _value;

        public override Type ValueType { get; } = typeof(UnityEngineInternal.MemorylessMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}