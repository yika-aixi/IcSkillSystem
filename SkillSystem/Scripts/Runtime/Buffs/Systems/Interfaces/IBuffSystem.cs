//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月14日-19:59
//CabinIcarus.SkillSystem.Runtime

using CabinIcarus.IcSkillSystem.Runtime.Systems;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces
{
    public interface IBuffSystem:ISkillSystem
    {
    }
    
    public interface IBuffSystem<in T>:IBuffSystem{}
}