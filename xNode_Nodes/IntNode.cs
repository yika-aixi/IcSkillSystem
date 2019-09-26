//using System;
//using UnityEngine;
//
//namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
//{
//    [CreateNodeMenu("CabinIcarus/Nodes/Int Value")]
//    public class IntNode:ValueNode
//    {
//        [SerializeField]
//        private int _value;
//
//        public override Type ValueType { get; } = typeof(int);
//        protected override object GetOutValue()
//        {
//            return _value;
//        }
//    }
//    
//    [CreateNodeMenu("CabinIcarus/Nodes/Condition/Int")]
//    public class IntConditionNode:ValueConditionNode<int>
//    {
//        protected override Func<bool> GetComparison()
//        {
//            return () => A == B;
//        }
//    }
//}