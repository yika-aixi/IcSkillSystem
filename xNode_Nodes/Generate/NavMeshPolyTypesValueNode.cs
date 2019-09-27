using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshPolyTypes Value")]
    public partial class NavMeshPolyTypesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.AI.NavMeshPolyTypes _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.AI.NavMeshPolyTypes);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}