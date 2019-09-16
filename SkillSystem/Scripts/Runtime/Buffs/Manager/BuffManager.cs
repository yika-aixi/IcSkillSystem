//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-18:59
//CabinIcarus.SkillSystem.Runtime

using System;
using System.Collections.Generic;
using Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Entitys;
using CabinIcarus.SkillSystem.Runtime.Buffs.Components;
using CabinIcarus.SkillSystem.Runtime.Buffs.Systems.Interfaces;
using UnityEngine;

namespace CabinIcarus.SkillSystem.Scripts.Runtime.Buffs
{
    public class BuffManager:IBuffManager
    {
        private readonly IBuffDriveSystem _driveSystem;
        private Dictionary<Type, List<IEntity>> _buffMap;

        public BuffManager(IBuffDriveSystem driveSystem)
        {
            _driveSystem = driveSystem;
        }

        /// <summary>
        /// 寻找指定buff的Entitys
        /// </summary>
        /// <param name="buffEntitys">寻找结果</param>
        /// <typeparam name="T">buff类型</typeparam>
        public void Find<T>(List<IEntity> buffEntitys) where T : IBuffDataComponent
        {
            buffEntitys.Clear();
            
            if (_buffMap.TryGetValue(typeof(T),out var result))
            {
                buffEntitys.AddRange(result);
            }
        }

        /// <summary>
        /// 寻找指定buff的Entitys
        /// </summary>
        /// <param name="buff">buff类型</param>
        /// <param name="buffEntitys">寻找结果</param>
        public void Find(IBuffDataComponent buff,List<IEntity> buffEntitys)
        {
            buffEntitys.Clear();
            
            if (_buffMap.TryGetValue(buff.GetType(),out var result))
            {
                buffEntitys.AddRange(result);
            }
        }

        public void AddBuff(IEntity entity, IBuffDataComponent buff)
        {
            if (!_buffMap.ContainsKey(buff.GetType()))
            {
                _buffMap.Add(buff.GetType(),new List<IEntity>());
            }

            _buffMap[buff.GetType()].Add(entity);
            
            entity.AddBuff(buff);
            
            _driveSystem.Create();
        }

        public void RemoveBuff(IEntity entity, IBuffDataComponent buff)
        {
            if (_buffMap.ContainsKey(buff.GetType()))
            {
                if (!_buffMap[buff.GetType()].Remove(entity))
                {
                    Debug.LogWarning($"实体{entity}得{buff},不是通过{nameof(IBuffManager.AddBuff)}操作添加得buff,无法删除");
                }
            }

            entity.RemoveBuff(buff);
        }
    }
}