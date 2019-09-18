using Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Entitys;

namespace CabinIcarus.SkillSystem.Runtime.Buffs.Components
{
    public interface IBuffMakerEntityComponent
    {
        IEntity Maker { get; set; }
    }
}