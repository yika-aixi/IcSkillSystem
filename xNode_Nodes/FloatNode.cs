using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Float Value")]
    public class FloatNode:ValueNode
    {
        [SerializeField]
        private float _value;

        public override Type ValueType { get; } = typeof(float);

        protected override object GetOutValue()
        {
            return _value;
        }
    }
    
    [CreateNodeMenu("CabinIcarus/Nodes/Float Condition")]
    public class FloatConditionNode:ValueConditionNode<float>
    {
        protected override Func<bool> GetComparison()
        {
            return () => Mathf.Approximately(A,B);
        }
    }
}