//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-19:28
//CabinIcarus.SkillSystem.Runtime

using System;
using System.Collections.Generic;
using Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Entitys;
using CabinIcarus.SkillSystem.Runtime.Buffs.Components;
using CabinIcarus.SkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.SkillSystem.Scripts.Runtime.Buffs
{
    public interface IBuffManager
    {
        /// <summary>
        /// 添加buff System
        /// </summary>
        /// <param name="buffSystem"></param>
        /// <returns></returns>
        IBuffManager AddBuffSystem(IBuffSystem buffSystem);
        
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

        void AddBuff(IEntity entity,IBuffDataComponent buff);

        bool RemoveBuff(IEntity entity,IBuffDataComponent buff);

        /// <summary>
        /// 获取指定类型得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetBuffs<T>(IEntity entity);
        
        /// <summary>
        /// 获取指定类型得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetBuffs<T>(IEntity entity,Predicate<T> match);
        
        /// <summary>
        /// 获取指定类型得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        void GetBuffs<T>(IEntity entity,List<T> buffs);
        
        /// <summary>
        /// 获取指定类型得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        void GetBuffs<T>(IEntity entity,Predicate<T> match,List<T> buffs);
        
        /// <summary>
        /// 指定得实体是否有该类型得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool HasBuff<T>(IEntity entity) where T:IBuffDataComponent;

        /// <summary>
        /// 指定得实体是否有匹配得buff
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="match"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool HasBuff<T>(IEntity entity,Predicate<T> match) where T:IBuffDataComponent;

        /// <summary>
        /// 更新
        /// </summary>
        void Update();
    }
}