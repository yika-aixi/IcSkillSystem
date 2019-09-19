//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-22:24
//Assembly-CSharp

using System;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes
{
    /// <summary>
    /// 临时的节点提示
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = false)]
    public class PortTooltipAttribute:Attribute
    {
        /// <summary>
        /// 输入时悬浮的提示
        /// </summary>
        public string InputTooltip { get; }
        
        /// <summary>
        /// 输出时的悬浮提示
        /// </summary>
        public string OutputTooltip { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputTooltip">节点是输入时悬浮的提示</param>
        /// <param name="outputTooltip">节点是输出时的悬浮提示</param>
        public PortTooltipAttribute(string inputTooltip="", string outputTooltip="")
        {
            InputTooltip = inputTooltip;
            OutputTooltip = outputTooltip;
        }
    }
}