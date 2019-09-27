using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshQuery Value")]
    public partial class NavMeshQueryValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.AI.NavMeshQuery _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.AI.NavMeshQuery);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}