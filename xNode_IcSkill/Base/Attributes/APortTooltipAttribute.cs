using System;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,AllowMultiple = false,Inherited = false)]
    public class APortTooltipAttribute:Attribute
    {
    }
}