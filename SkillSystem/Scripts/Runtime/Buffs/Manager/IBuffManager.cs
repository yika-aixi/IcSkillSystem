//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-19:28
//CabinIcarus.SkillSystem.Runtime

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs
{
    public interface IBuffManager<T> where T : IBuffDataComponent 
    {
        /// <summary>
        /// 添加buff System
        /// </summary>
        /// <param name="buffSystem"></param>
        /// <returns></returns>
        IBuffManager<T> AddBuffSystem(IBuffSystem buffSystem);
        
        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <param name="entitys"></param>
        void GetAllEntity(List<IEntity> entitys);
        
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        void AddEntity(IEntity entity);
        
        /// <summary>
        /// 销毁实体
        /// </summary>
        /// <param name="entity"></param>
        void DestroyEntity(IEntity entity);

        void AddBuff(IEntity entity,T buff);

        bool RemoveBuff(IEntity entity,T buff);
        
        /// <summary>
        /// 获取指定类型得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        void GetBuffs<T1>(IEntity entity,List<T1> buffs) where T1 : T;

        /// <summary>
        /// 获取指定类型得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        void GetBuffs<T1>(IEntity entity,Predicate<T1> match,List<T1> buffs) where T1 : T;
        
        /// <summary>
        /// 指定得实体是否有该类型得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        bool HasBuff<T1>(IEntity entity) where T1 : T;

        /// <summary>
        /// 指定得实体是否有该类型得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="buffType"></typeparam>
        /// <returns></returns>
        bool HasBuff(IEntity entity, Type buffType);

        /// <summary>
        /// 指定得实体是否有匹配得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="match"></param>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        bool HasBuff<T1>(IEntity entity, Predicate<T1> match) where T1 : T;

        /// <summary>
        /// 指定得实体是否有匹配得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        bool HasBuff(IEntity entity, Type buffType, Predicate<T> match);

        /// <summary>
        /// 更新
        /// </summary>
        void Update();
    }
}