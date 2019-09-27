using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshHit Value")]
    public partial class NavMeshHitValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshHit _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshHit);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}