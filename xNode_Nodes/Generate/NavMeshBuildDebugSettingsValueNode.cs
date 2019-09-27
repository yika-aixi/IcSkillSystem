using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshBuildDebugSettings Value")]
    public partial class NavMeshBuildDebugSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshBuildDebugSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshBuildDebugSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}