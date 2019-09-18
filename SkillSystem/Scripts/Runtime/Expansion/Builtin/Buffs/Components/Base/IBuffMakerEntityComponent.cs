using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    public interface IBuffMakerEntityComponent
    {
        IEntity Maker { get; set; }
    }
}