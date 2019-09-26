//using System;
//using UnityEngine;
//
//namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
//{
//    [CreateNodeMenu("CabinIcarus/Nodes/Bool Value")]
//    public class BoolNode:ValueNode
//    {
//        [SerializeField]
//        private bool _value;
//
//        public override Type ValueType { get; } = typeof(bool);
//
//        protected override object GetOutValue()
//        {
//            return _value;
//        }
//    }
//    
//    [CreateNodeMenu("CabinIcarus/Nodes/Condition/Bool")]
//    public class BoolConditionNode:ValueConditionNode<bool>
//    {
//        protected override Func<bool> GetComparison()
//        {
//            return () => A == B;
//        }
//    }
//}