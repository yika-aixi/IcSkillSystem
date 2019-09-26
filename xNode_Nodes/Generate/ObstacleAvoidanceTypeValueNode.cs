using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/ObstacleAvoidanceType Value")]
    public partial class ObstacleAvoidanceTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.ObstacleAvoidanceType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.ObstacleAvoidanceType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}