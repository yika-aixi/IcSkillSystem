using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Buffs.Exceptions;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs
{
    public interface IStructBuffDataComponent : IBuffDataComponent
    {
        int ID { get;}
    }
    
    public class StructBuffManager:IBuffManager<IStructBuffDataComponent>
    {
        struct StructBuffInfo
        {
            public int ID;
            public IntPtr Ptr;

            public StructBuffInfo(int id, IntPtr ptr)
            {
                ID = id;
                Ptr = ptr;
            }
        }
        
        private List<IEntity> _entities;
        
        private Dictionary<IEntity,List<StructBuffInfo>> _buffMap;
        
        private List<IBuffCreateSystem<IStructBuffDataComponent>> _createSystems;

        private List<IBuffUpdateSystem> _updateSystems;

        private List<IBuffDestroySystem<IStructBuffDataComponent>> _destroySystems;

        public StructBuffManager()
        {
            _entities = new List<IEntity>();
            _buffMap = new Dictionary<IEntity, List<StructBuffInfo>>();
            _createSystems = new List<IBuffCreateSystem<IStructBuffDataComponent>>();
            _updateSystems = new List<IBuffUpdateSystem>();
            _destroySystems = new List<IBuffDestroySystem<IStructBuffDataComponent>>();
        }

        public IBuffManager<IStructBuffDataComponent> AddBuffSystem(IBuffSystem buffSystem)
        {
            if (_createSystems.Exists(x=>x.GetType() == buffSystem.GetType()) ||
                _updateSystems.Exists(x=>x.GetType() == buffSystem.GetType()) ||
                _destroySystems.Exists(x=>x.GetType() == buffSystem.GetType()))
            {
                Debug.LogWarning($"{buffSystem.GetType()} System already exists, skip");
                return this;
            }
            
            if (buffSystem is IBuffCreateSystem<IStructBuffDataComponent> createSystem)
            {
                _createSystems.Add(createSystem);
            }
            
            if (buffSystem is IBuffUpdateSystem updateSystem)
            {
                _updateSystems.Add(updateSystem);
            }
            
            if (buffSystem is IBuffDestroySystem<IStructBuffDataComponent> destroySystem)
            {
                _destroySystems.Add(destroySystem);
            }

            return this;
        }

        public void GetAllEntity(List<IEntity> entitys)
        {
            entitys.Clear();
            entitys.AddRange(_entities);
        }

        public void AddBuff(IEntity entity, IStructBuffDataComponent buff)
        {
            _checkType(buff);
            
            if (!_entities.Contains(entity))
            {
                _entities.Add(entity);
                _buffMap.Add(entity,new List<StructBuffInfo>());
            }

#if UNITY_EDITOR
            foreach (var structBuffInfo in _buffMap[entity])
            {
                if (structBuffInfo.ID == buff.ID)
                {
                    throw new ArgumentException($"An Buff with the same id already exists. ID:{buff.ID}");
                }
            }
#endif
            _buffMap[entity].Add(new StructBuffInfo(buff.ID,buff.ToPtr(true)));
            
            foreach (var createSystem in _createSystems)
            {
                if (createSystem.Filter(entity,buff))
                {
                    createSystem.Create(entity,buff);
                }    
            }
        }

        private static void _checkType(object obj)
        {
#if UNITY_EDITOR
            var type = obj.GetType();
            if (!type.IsValueType)
            {
                throw new TypeErrorException($"{type} not is Struct Type.", typeof(ValueType));
            }

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var fieldInfo in fields)
            {
                if (!fieldInfo.FieldType.IsValueType)
                {
                    throw new TypeErrorException($"{type.Name}.{fieldInfo.Name} not is Value Type.", typeof(ValueType));
                }
            }

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var propertyInfo in properties)
            {
                if (!propertyInfo.PropertyType.IsValueType)
                {
                    throw new TypeErrorException($"{type.Name}.{propertyInfo.Name} not is Value Type.", typeof(ValueType));
                }
            }
#endif
        }

        public bool RemoveBuff(IEntity entity, IStructBuffDataComponent buff)
        {
            bool result = false;
            if (_entities.Contains(entity))
            {
                var buffs = _buffMap[entity];
                int index = -1;
                for (var i = 0; i < buffs.Count; i++)
                {
                    var structBuffInfo = buffs[i];
                    if (structBuffInfo.ID == buff.ID)
                    {
                        result = true;
                        index = i;
                    }
                }

                if (result)
                {
                    buffs[index].Ptr.Free();
                     
                    buffs.RemoveAt(index);
                }
            }

            if (result)
            {
                foreach (var destroySystem in _destroySystems)
                {
                    if (destroySystem.Filter(entity,buff))
                    {
                        destroySystem.Destroy(entity,buff);
                    }    
                }
            }

            return result;
        }

        public void GetBuffs<T>(IEntity entity, List<T> buffs) where T : IStructBuffDataComponent
        {
            GetBuffs(entity, null, buffs);
        }

        public void GetBuffs<T>(IEntity entity, Predicate<T> match, List<T> buffs) where T : IStructBuffDataComponent
        {
            buffs.Clear();
            if (_entities.Contains(entity))
            {
                foreach (var buff in _buffMap[entity])
                {
                    if (buff is T tBuff)
                    {
                        if (match != null)
                        {
                            if (!match(tBuff))
                            {
                                continue;
                            }
                        }
                        
                        buffs.Add(tBuff);
                    }
                }
            }
        }

        public bool HasBuff<T>(IEntity entity) where T : IStructBuffDataComponent
        {
            return HasBuff(entity, typeof(T));
        }

        public bool HasBuff(IEntity entity, Type buffType)
        {
            if (!_entities.Contains(entity))
            {
                return false;
            }

            return _buffMap[entity].Select(x=>x.Ptr.ToBuff<IStructBuffDataComponent>()).Any(buffType.IsInstanceOfType);
        }

        public bool HasBuff<T>(IEntity entity, Predicate<T> match) where T : IStructBuffDataComponent
        {
            return HasBuff(entity, typeof(T), x=>match((T) x));
        }

        public bool HasBuff(IEntity entity, Type buffType, Predicate<IStructBuffDataComponent> match)
        {
            if (!_entities.Contains(entity))
            {
                return false;
            }
            
            return _buffMap[entity].Select(x=>x.Ptr.ToBuff<IStructBuffDataComponent>()).Any(x=> buffType.IsInstanceOfType(x) && match(x));
        }

        public void AddEntity(IEntity entity)
        {
            if (!_entities.Contains(entity))
            {
                _entities.Add(entity);
                _buffMap.Add(entity,new List<StructBuffInfo>());
            }
        }

        public void DestroyEntity(IEntity entity)
        {
            if (_entities.Contains(entity))
            {
                foreach (var buff in _buffMap[entity].ToList())
                {
                    RemoveBuff(entity, buff.Ptr.ToBuff<IStructBuffDataComponent>());
                }
                
                _entities.Remove(entity);
                _buffMap.Remove(entity);
            }
        }

        public void Update()
        {
            for (var i = 0; i < _entities.Count; i++)
            {
                var entity = _entities[i];
                
                foreach (var updateSystem in _updateSystems)
                {
                    if (updateSystem.Filter(entity))
                    {
                        updateSystem.Execute(entity);
                    }
                }
            }
        }
    }

    static class StructBuffEx
    {
        public static IntPtr ToPtr(this IStructBuffDataComponent self,bool deleteOld)
        {
            IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(self));
            Marshal.StructureToPtr(self,pnt,deleteOld);

            return pnt;
        }

        public static T ToBuff<T>(this IntPtr self) where T : IStructBuffDataComponent
        {
            return Marshal.PtrToStructure<T>(self);
        }
        
        public static void Free(this IntPtr self)
        {
            Marshal.FreeHGlobal(self);
        }
    }
}