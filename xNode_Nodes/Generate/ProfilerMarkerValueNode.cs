using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ProfilerMarker Value")]
    public partial class ProfilerMarkerValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Profiling.ProfilerMarker _value;

        public override Type ValueType { get; } = typeof(Unity.Profiling.ProfilerMarker);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}