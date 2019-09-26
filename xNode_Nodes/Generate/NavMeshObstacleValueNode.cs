using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshObstacle Value")]
    public partial class NavMeshObstacleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshObstacle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshObstacle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}