using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/NPBehaveExampleHelloBlackboardsAI Value")]
    public partial class NPBehaveExampleHelloBlackboardsAIValueNode:ValueNode
    {
        [SerializeField]
        private NPBehaveExampleHelloBlackboardsAI _value;

        public override Type ValueType { get; } = typeof(NPBehaveExampleHelloBlackboardsAI);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}