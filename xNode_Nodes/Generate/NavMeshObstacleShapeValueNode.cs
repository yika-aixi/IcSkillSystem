using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshObstacleShape Value")]
    public partial class NavMeshObstacleShapeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshObstacleShape _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshObstacleShape);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}