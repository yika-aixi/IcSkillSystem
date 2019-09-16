//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-19:34
//CabinIcarus.SkillSystem.Runtime

namespace CabinIcarus.SkillSystem.Runtime.Buffs.Systems.Interfaces
{
    public interface IBuffDriveSystem:IBuffCreateSystem,IBuffUpdateSystem,IBuffDestroySystem
    {
        IBuffDriveSystem AddBuffSystem(IBuffSystem buffSystem);
    }
}