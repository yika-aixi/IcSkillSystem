using System;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,AllowMultiple = false,Inherited = false)]
    public class APortTooltipAttribute:Attribute
    {
    }
}