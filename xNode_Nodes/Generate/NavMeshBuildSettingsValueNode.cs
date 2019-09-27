using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshBuildSettings Value")]
    public partial class NavMeshBuildSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshBuildSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshBuildSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}