using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshWorld Value")]
    public partial class NavMeshWorldValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.AI.NavMeshWorld _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.AI.NavMeshWorld);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}