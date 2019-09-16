//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-19:28
//CabinIcarus.SkillSystem.Runtime

using System.Collections.Generic;
using Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Entitys;
using CabinIcarus.SkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.SkillSystem.Scripts.Runtime.Buffs
{
    public interface IBuffManager
    {
        /// <summary>
        /// 寻找指定buff的Entitys
        /// </summary>
        /// <param name="buffEntitys">寻找结果</param>
        /// <typeparam name="T">buff类型</typeparam>
        void Find<T>(List<IEntity> buffEntitys) where T : IBuffDataComponent;

        /// <summary>
        /// 寻找指定buff的Entitys
        /// </summary>
        /// <param name="buff">buff类型</param>
        /// <param name="buffEntitys">寻找结果</param>
        void Find(IBuffDataComponent buff, List<IEntity> buffEntitys);

        void AddBuff(IEntity entity, IBuffDataComponent buff);

        void RemoveBuff(IEntity entity,IBuffDataComponent buff);
    }
}