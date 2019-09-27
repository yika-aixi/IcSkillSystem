using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshPathStatus Value")]
    public partial class NavMeshPathStatusValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshPathStatus _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshPathStatus);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}