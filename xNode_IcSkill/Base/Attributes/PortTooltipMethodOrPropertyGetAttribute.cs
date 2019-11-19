using System;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes
{
    /// <summary>
    /// 临时的节点提示 -- 方法或属性名, 方法优先级高于属性
    /// string xxx(){}
    /// string xxxxx => ""
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,AllowMultiple = false,Inherited = false)]
    public class PortTooltipMethodOrPropertyGetAttribute:APortTooltipAttribute
    {
        /// <summary>
        /// 方法或属性名
        /// </summary>
        public string MethodOrPropertyName { get; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tooltip">节点是输入时悬浮的提示</param>
        public PortTooltipMethodOrPropertyGetAttribute(string tooltip)
        {
            MethodOrPropertyName = tooltip;
        }
    }
}