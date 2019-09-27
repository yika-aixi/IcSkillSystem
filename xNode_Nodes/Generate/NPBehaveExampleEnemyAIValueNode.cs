using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/NPBehaveExampleEnemyAI Value")]
    public partial class NPBehaveExampleEnemyAIValueNode:ValueNode
    {
        [SerializeField]
        private NPBehaveExampleEnemyAI _value;

        public override Type ValueType { get; } = typeof(NPBehaveExampleEnemyAI);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}