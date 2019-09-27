using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/NPBehaveExampleSwarmEnemyAI Value")]
    public partial class NPBehaveExampleSwarmEnemyAIValueNode:ValueNode
    {
        [SerializeField]
        private NPBehaveExampleSwarmEnemyAI _value;

        public override Type ValueType { get; } = typeof(NPBehaveExampleSwarmEnemyAI);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}