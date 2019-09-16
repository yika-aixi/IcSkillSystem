//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-19:04
//CabinIcarus.SkillSystem.Runtime

using CabinIcarus.SkillSystem.Runtime.Buffs.Components;
using CabinIcarus.SkillSystem.Scripts.Runtime.Buffs.Events;

namespace Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Entitys
{
    public interface IEntity
    {
        event BuffRemove OnBuffRemove;
        
        void AddBuff(IBuffDataComponent buff);

        void RemoveBuff(IBuffDataComponent buff);

        bool HasBuff(IBuffDataComponent buff);
    }
}