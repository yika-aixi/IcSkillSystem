using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshBuildDebugFlags Value")]
    public partial class NavMeshBuildDebugFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshBuildDebugFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshBuildDebugFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}