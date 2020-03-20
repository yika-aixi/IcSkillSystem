using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    /// <summary>
    /// 值节点
    /// </summary>
    public abstract class ValueNode<T>:ANPNode<T>
    {
        protected sealed override T GetOutValue()
        {
            return GetTValue();
        }

        protected sealed override object GetPortValue(NodePort port)
        {
            return GetTValue(port);
        }

        protected virtual T GetTValue(NodePort port)
        {
            return default;
        }

        protected abstract T GetTValue();
    }
    
    /// <summary>
    /// 动态值节点
    /// </summary>
    public abstract class DynamicValueNode:ValueNode<object>
    {
        public const string ValueOutPutPortName = "DynamicValue";

        /// <summary>
        /// 当是可改变类型是,只会显示该类型可以分配了的类型,默认为system.object
        /// </summary>
        public virtual Type BaseType { get; } = typeof(object);
        
        protected Type GetCurrentValueType()
        {
            var port = GetOutputPort(ValueOutPutPortName);

            return port?.ValueType;
        }

        protected sealed override object GetTValue()
        {
            return GetDynamicValue();
        }

        protected sealed override object GetTValue(NodePort port)
        {
            if (port.fieldName == ValueOutPutPortName)
            {
                return GetDynamicValue();
            }
            
            return GetOutValue(port);
        }
        protected abstract object GetDynamicValue();

        protected virtual object GetOutValue(NodePort port)
        {
            return GetDynamicValue();
        }
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