//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月28日-20:42
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Utils;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs
{
    public static class BuffManagerExpansion
    {
        private static ReferenceObjectPool _buffPool;
        
        static BuffManagerExpansion()
        {
            _buffPool = new ReferenceObjectPool();
            _buffPool.RecedeCache = true;
        }

        public static T CreateBuff<T>(this IBuffManager<IBuffDataComponent> self, params object[] args) where T : IBuffDataComponent
        {
            return (T) self.CreateBuff(typeof(T), args);
        }
        
        public static IBuffDataComponent CreateBuff(this IBuffManager<IBuffDataComponent> self,Type buffType, params object[] args)
        {
            if (!typeof(IBuffDataComponent).IsAssignableFrom(buffType))
            {
                return null;
            }
            
            var buff = (IBuffDataComponent) _buffPool.GetObject(buffType,args);

            return buff;
        }

        public static T CreateAndAddBuff<T>(this IBuffManager<IBuffDataComponent> self,IEntity entity, Action<T> buffSetting,params object[] args) where T : IBuffDataComponent
        {
            if (buffSetting == null)
            {
                return (T) self.CreateAndAddBuff(typeof(T), entity, null, args);
            }
            else
            {
                return (T) self.CreateAndAddBuff(typeof(T), entity, x=>buffSetting.Invoke((T) x), args);
            }
        }
        
        public static IBuffDataComponent CreateAndAddBuff(this IBuffManager<IBuffDataComponent> self,Type buffType,IEntity entity, Action<IBuffDataComponent> buffSetting,params object[] args)
        {
            IBuffDataComponent buff = self.CreateBuff(buffType, args);
            
            if (buff == null)
            {
                return null;
            }
            
            buffSetting?.Invoke(buff);
            
            self.AddBuff(entity,buff);

            return buff;
        }
        
        public static void RemoveBuffEx(this IBuffManager<IBuffDataComponent> self,IEntity entity,IBuffDataComponent buff)
        {
            if (self.RemoveBuff(entity, buff))
            {
                _buffPool.Recede(buff);
            }
#if UNITY_EDITOR
            else
            {
                UnityEngine.Debug.LogWarning($"{entity} Remove {buff} Buff failure!");
            }
#endif
        }
        
        public static void DestroyEntityEx(this IBuffManager<IBuffDataComponent> self,IEntity entity)
        {
            List<IBuffDataComponent> _buffs = new List<IBuffDataComponent>();
            
            self.GetBuffs(entity,_buffs);
            
            for (var i = 0; i < _buffs.Count; i++)
            {
                _buffPool.Recede(_buffs[i]);
            }
            
            self.DestroyEntity(entity);
        }
    }
}