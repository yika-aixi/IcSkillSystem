using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshQueryFilter Value")]
    public partial class NavMeshQueryFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshQueryFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshQueryFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}