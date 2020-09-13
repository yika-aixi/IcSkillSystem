//Create: Icarus
//ヾ(•ω•`)o
//2020-09-13 11:11
//CabinIcarus.IcSkillSystem.xNodeIc.Base

using System;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NodeTooltipAttribute:APortTooltipAttribute
    {
        public readonly string Tooltip;

        public NodeTooltipAttribute(string tooltip)
        {
            Tooltip = tooltip;
        }
    }
}