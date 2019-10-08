using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Buffs.Exceptions;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs
{
    public class StructBuffManager:IBuffManager
    {
        private List<IEntity> _entities;
        
        private Dictionary<IEntity,List<IBuffDataComponent>> _buffMap;
        
        private List<IBuffCreateSystem> _createSystems;

        private List<IBuffUpdateSystem> _updateSystems;

        private List<IBuffDestroySystem> _destroySystems;

        public StructBuffManager()
        {
            _entities = new List<IEntity>();
            _buffMap = new Dictionary<IEntity, List<IBuffDataComponent>>();
            _createSystems = new List<IBuffCreateSystem>();
            _updateSystems = new List<IBuffUpdateSystem>();
            _destroySystems = new List<IBuffDestroySystem>();
        }

        public IBuffManager AddBuffSystem(IBuffSystem buffSystem)
        {
            if (_createSystems.Exists(x=>x.GetType() == buffSystem.GetType()) ||
                _updateSystems.Exists(x=>x.GetType() == buffSystem.GetType()) ||
                _destroySystems.Exists(x=>x.GetType() == buffSystem.GetType()))
            {
                Debug.LogWarning($"{buffSystem.GetType()} System already exists, skip");
                return this;
            }
            
            if (buffSystem is IBuffCreateSystem createSystem)
            {
                _createSystems.Add(createSystem);
            }
            
            if (buffSystem is IBuffUpdateSystem updateSystem)
            {
                _updateSystems.Add(updateSystem);
            }
            
            if (buffSystem is IBuffDestroySystem destroySystem)
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

        public void AddBuff(IEntity entity, IBuffDataComponent buff)
        {
            _checkType(buff);
            
            if (!_entities.Contains(entity))
            {
                _entities.Add(entity);
                _buffMap.Add(entity,new List<IBuffDataComponent>());
            }
            
            _buffMap[entity].Add(buff);
            
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

        public bool RemoveBuff(IEntity entity, IBuffDataComponent buff)
        {
            bool result = false;
            if (_entities.Contains(entity))
            {
                var buffs = _buffMap[entity];
                result = buffs.Remove(buff);
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

        public void GetBuffs<T>(IEntity entity, List<T> buffs)
        {
            GetBuffs(entity, null, buffs);
        }

        public void GetBuffs<T>(IEntity entity, Predicate<T> match, List<T> buffs)
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

        public bool HasBuff<T>(IEntity entity) where T : IBuffDataComponent
        {
            return HasBuff(entity, typeof(T));
        }

        public bool HasBuff(IEntity entity, Type buffType)
        {
            if (!_entities.Contains(entity))
            {
                return false;
            }

            return _buffMap[entity].Exists(buffType.IsInstanceOfType);
        }

        public bool HasBuff<T>(IEntity entity, Predicate<T> match) where T : IBuffDataComponent
        {
            return HasBuff(entity, typeof(T), x=>match((T) x));
        }

        public bool HasBuff(IEntity entity, Type buffType, Predicate<IBuffDataComponent> match)
        {
            if (!_entities.Contains(entity))
            {
                return false;
            }
            
            return _buffMap[entity].Exists(x=> buffType.IsInstanceOfType(x) && match(x));
        }

        public void AddEntity(IEntity entity)
        {
            if (!_entities.Contains(entity))
            {
                _entities.Add(entity);
                _buffMap.Add(entity,new List<IBuffDataComponent>());
            }
        }

        public void DestroyEntity(IEntity entity)
        {
            if (_entities.Contains(entity))
            {
                foreach (var buff in _buffMap[entity].ToList())
                {
                    RemoveBuff(entity, buff);
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
}