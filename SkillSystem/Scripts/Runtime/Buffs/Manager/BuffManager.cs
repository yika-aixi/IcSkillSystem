//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-18:59
//CabinIcarus.SkillSystem.Runtime

using System;
using System.Collections.Generic;
using System.Linq;
using Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Entitys;
using CabinIcarus.SkillSystem.Runtime.Buffs.Components;
using CabinIcarus.SkillSystem.Runtime.Buffs.Systems.Interfaces;
using UnityEngine;

namespace CabinIcarus.SkillSystem.Scripts.Runtime.Buffs
{
    public class BuffManager:IBuffManager
    {
        private List<IEntity> _entities;
        
        private Dictionary<IEntity,List<IBuffDataComponent>> _buffMap;
        
        private List<IBuffCreateSystem> _createSystems;

        private List<IBuffUpdateSystem> _updateSystems;

        private List<IBuffDestroySystem> _destroySystems;

        public BuffManager()
        {
            _entities = new List<IEntity>();
            _buffMap = new Dictionary<IEntity, List<IBuffDataComponent>>();
            _createSystems = new List<IBuffCreateSystem>();
            _updateSystems = new List<IBuffUpdateSystem>();
            _destroySystems = new List<IBuffDestroySystem>();
        }

        public IBuffManager AddBuffSystem(IBuffSystem buffSystem)
        {
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

        public void AddBuff(IEntity entity, IBuffDataComponent buff)
        {
            foreach (var createSystem in _createSystems)
            {
                if (createSystem.Filter(entity,buff))
                {
                    createSystem.Create(entity,buff);
                }    
            }
            
            if (!_entities.Contains(entity))
            {
                _entities.Add(entity);
                _buffMap.Add(entity,new List<IBuffDataComponent>());
            }
            
            _buffMap[entity].Add(buff);
        }

        public void RemoveBuff(IEntity entity, IBuffDataComponent buff)
        {
            foreach (var destroySystem in _destroySystems)
            {
                if (destroySystem.Filter(entity,buff))
                {
                    destroySystem.Destroy(entity,buff);
                }    
            }
            
            if (_entities.Contains(entity))
            {
                _buffMap[entity].Remove(buff);
            }
        }

        public IEnumerable<T> GetBuffs<T>(IEntity entity)
        {
            if (_entities.Contains(entity))
            {
                return _buffMap[entity].Where(x => x.GetType() == typeof(T)).Cast<T>();
            }

            return null;
        }
        
        public void GetBuffs<T>(IEntity entity, List<T> buffs)
        {
            buffs.Clear();
            if (_entities.Contains(entity))
            {
                foreach (var buff in _buffMap[entity])
                {
                    if (buff.GetType() == typeof(T))
                    {
                        buffs.Add((T) buff);
                    }
                }
            }
        }

        public bool HasBuff<T>(IEntity entity) where T : IBuffDataComponent
        {
            if (!_buffMap.ContainsKey(entity))
            {
                return false;
            }

            return _buffMap[entity].Exists(x => x.GetType() == typeof(T));
        }

        public bool HasBuff<T>(IEntity entity, Predicate<T> match) where T : IBuffDataComponent
        {
            if (!_buffMap.ContainsKey(entity))
            {
                return false;
            }
            
            return _buffMap[entity].Exists(x=>match((T) x));
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
                foreach (var buff in _buffMap[entity])
                {
                    RemoveBuff(entity,buff);
                }

                _buffMap.Remove(entity);
                _entities.Remove(entity);
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