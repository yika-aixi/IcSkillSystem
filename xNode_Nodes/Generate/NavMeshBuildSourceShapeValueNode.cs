using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshBuildSourceShape Value")]
    public partial class NavMeshBuildSourceShapeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshBuildSourceShape _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshBuildSourceShape);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}