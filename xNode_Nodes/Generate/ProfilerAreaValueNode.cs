using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ProfilerArea Value")]
    public partial class ProfilerAreaValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Profiling.ProfilerArea _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Profiling.ProfilerArea);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}