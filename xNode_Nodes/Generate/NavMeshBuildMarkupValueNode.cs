using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshBuildMarkup Value")]
    public partial class NavMeshBuildMarkupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshBuildMarkup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshBuildMarkup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}