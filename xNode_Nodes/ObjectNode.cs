using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Object Value")]
    public class ObjectNode:ValueNode
    {
        [SerializeField]
        private Object _value;

        public override Type ValueType { get; } = typeof(Object);

        public override bool IsChangeValueType { get; } = true;

        public override Type BaseType { get; } = typeof(Object);

        protected override object GetOutValue()
        {
            return _value;
        }
    }
    
    [CreateNodeMenu("CabinIcarus/Nodes/Condition/Object")]
    public class ObjectConditionNode:ValueConditionNode<Object>
    {
        protected override Func<bool> GetComparison()
        {
            return () => A == B;
        }
    }
}