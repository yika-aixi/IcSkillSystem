using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    /// <summary>
    /// 值节点,为了严格性,请在实现类在output一个实际类型,如IntNode
    /// </summary>
    public abstract class ValueNode:Node,ISkillSystemNode
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
        public abstract Type ValueType { get; set; }


        /// <summary>
        /// 是否能改变Value类型
        /// </summary>
        public virtual bool IsChangeValueType { get; } = false;
        
        /// <summary>
        /// 获取输出 value
        /// </summary>
        /// <returns></returns>
        protected abstract object GetOutValue();
    }
}