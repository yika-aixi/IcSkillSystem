using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/EnemyA Value")]
    public partial class EnemyAValueNode:ValueNode
    {
        [SerializeField]
        private NPBehave.Examples.ReusableSubtrees.EnemyA _value;

        public override Type ValueType { get; } = typeof(NPBehave.Examples.ReusableSubtrees.EnemyA);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}