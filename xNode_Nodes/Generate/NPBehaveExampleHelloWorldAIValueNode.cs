using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/NPBehaveExampleHelloWorldAI Value")]
    public partial class NPBehaveExampleHelloWorldAIValueNode:ValueNode
    {
        [SerializeField]
        private NPBehaveExampleHelloWorldAI _value;

        public override Type ValueType { get; } = typeof(NPBehaveExampleHelloWorldAI);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}