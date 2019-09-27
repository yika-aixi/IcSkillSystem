using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshLocation Value")]
    public partial class NavMeshLocationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.AI.NavMeshLocation _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.AI.NavMeshLocation);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}