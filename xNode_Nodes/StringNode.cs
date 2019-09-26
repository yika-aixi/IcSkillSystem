using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/String Value")]
    public class StringNode:ValueNode
    {
        [SerializeField]
        private string _value;

        public override Type ValueType { get; } = typeof(string);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
    
    [CreateNodeMenu("CabinIcarus/Nodes/Condition/String")]
    public class StringConditionNode:ValueConditionNode<string>
    {
        protected override Func<bool> GetComparison()
        {
            return () => A == B;
        }
    }
}