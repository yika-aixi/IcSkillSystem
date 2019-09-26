using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshAgent Value")]
    public partial class NavMeshAgentValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshAgent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshAgent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}