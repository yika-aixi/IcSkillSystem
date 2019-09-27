using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshCollectGeometry Value")]
    public partial class NavMeshCollectGeometryValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshCollectGeometry _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshCollectGeometry);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}