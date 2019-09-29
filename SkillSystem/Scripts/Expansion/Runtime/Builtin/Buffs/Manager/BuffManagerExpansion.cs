//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月28日-20:42
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Utils;
using UnityEngine;

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

        public static T CreateBuff<T>(this IBuffManager self, params object[] args) where T : IBuffDataComponent
        {
            return (T) self.CreateBuff(typeof(T), args);
        }
        
        public static IBuffDataComponent CreateBuff(this IBuffManager self,Type buffType, params object[] args)
        {
            if (!typeof(IBuffDataComponent).IsAssignableFrom(buffType))
            {
                return null;
            }
            
            var buff = (IBuffDataComponent) _buffPool.GetObject(buffType,args);

            return buff;
        }

        public static T CreateAndAddBuff<T>(this IBuffManager self,IEntity entity, Action<T> buffSetting,params object[] args) where T : IBuffDataComponent
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
        
        public static IBuffDataComponent CreateAndAddBuff(this IBuffManager self,Type buffType,IEntity entity, Action<IBuffDataComponent> buffSetting,params object[] args)
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
        
        public static void RemoveBuffEx(this IBuffManager self,IEntity entity,IBuffDataComponent buff)
        {
            self.RemoveBuff(entity, buff);
            
            _buffPool.Recede(buff);
        }
    }
}