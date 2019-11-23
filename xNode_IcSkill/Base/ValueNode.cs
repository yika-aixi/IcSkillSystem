using System;
using CabinIcarus.IcSkillSystem.Runtime.Nodes;
using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    /// <summary>
    /// 值节点
    /// </summary>
    public abstract class ValueNode:Node,IIcSkillSystemNode
    {
        public const string ValueOutPutPortName = "Value";

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == ValueOutPutPortName)
            {
                return GetOutValue();
            }
            
            return this;
        }

        /// <summary>
        /// Value类型
        /// </summary>
        public abstract Type ValueType { get;}


        /// <summary>
        /// 是否能改变Value类型
        /// </summary>
        public virtual bool IsChangeValueType { get; } = false;

        /// <summary>
        /// 当是可改变类型是,只会显示该类型可以分配了的类型,默认为system.object
        /// </summary>
        public virtual Type BaseType { get; } = typeof(object);
        
        /// <summary>
        /// 获取输出 value
        /// </summary>
        /// <returns></returns>
        protected abstract object GetOutValue();

        public IcSkillGroup SkillGroup { get; set; }
    }
    
    /// <summary>
    /// 值节点的条件节点
    /// </summary>
    public abstract class ValueConditionNode<T>:ANPNode<Func<bool>>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        protected T A;

        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        protected T B;
        
        protected sealed override Func<bool> GetOutValue()
        {
            A = GetInputValue(nameof(A), A);
            B = GetInputValue(nameof(B), B);
            
            return GetComparison();
        }

        protected abstract Func<bool> GetComparison();
    }
}