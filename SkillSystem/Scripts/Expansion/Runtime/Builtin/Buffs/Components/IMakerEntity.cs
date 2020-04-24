using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    public interface IMakerEntity
    {
        ECSResources<IIcSkSEntity> Entity { get; set; }
    }
}