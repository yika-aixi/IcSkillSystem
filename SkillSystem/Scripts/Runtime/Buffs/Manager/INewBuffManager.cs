using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs
{
    public interface INewBuffManager<in T> where T: IBuffSystem
    {
        INewBuffManager<T> AddBuffSystem(T buffSystem);
    }
}