using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshBuildSource Value")]
    public partial class NavMeshBuildSourceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshBuildSource _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshBuildSource);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}