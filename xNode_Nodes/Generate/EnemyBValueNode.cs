using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/EnemyB Value")]
    public partial class EnemyBValueNode:ValueNode
    {
        [SerializeField]
        private NPBehave.Examples.ReusableSubtrees.EnemyB _value;

        public override Type ValueType { get; } = typeof(NPBehave.Examples.ReusableSubtrees.EnemyB);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}