using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshTriangulation Value")]
    public partial class NavMeshTriangulationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshTriangulation _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshTriangulation);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}