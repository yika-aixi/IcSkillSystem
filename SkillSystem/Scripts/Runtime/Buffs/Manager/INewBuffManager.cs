using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs
{
    public interface INewBuffManager
    {
        /// <summary>
        /// 添加buff System
        /// </summary>
        /// <param name="buffSystem"></param>
        /// <returns></returns>
        INewBuffManager AddBuffSystem(IBuffSystem buffSystem);
        
        
    }
}