using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshData Value")]
    public partial class NavMeshDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}