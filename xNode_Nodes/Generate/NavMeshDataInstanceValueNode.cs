using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshDataInstance Value")]
    public partial class NavMeshDataInstanceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshDataInstance _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshDataInstance);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}