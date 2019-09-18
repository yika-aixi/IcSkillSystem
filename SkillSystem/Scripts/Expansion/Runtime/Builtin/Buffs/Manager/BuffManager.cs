//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-18:59
//CabinIcarus.SkillSystem.Runtime

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs
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

        public void GetAllEntity(List<IEntity> entitys)
        {
            entitys.Clear();
            entitys.AddRange(_entities);
        }

        public void AddBuff(IEntity entity, IBuffDataComponent buff)
        {
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

        public bool RemoveBuff(IEntity entity, IBuffDataComponent buff)
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
                var buffs = _buffMap[entity];
                return buffs.Remove(buff);
            }

            return false;
        }

        public IEnumerable<T> GetBuffs<T>(IEntity entity)
        {
            List<T> buffs = new List<T>();

            GetBuffs(entity, buffs);

            return buffs.Count == 0 ? null : buffs;
        }

        public IEnumerable<T> GetBuffs<T>(IEntity entity, Predicate<T> match)
        {
            List<T> buffs = new List<T>();

            GetBuffs(entity, match,buffs);

            return buffs.Count == 0 ? null : buffs;
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
            if (!_entities.Contains(entity))
            {
                return false;
            }

            return _buffMap[entity].Exists(x => x is T);
        }

        public bool HasBuff<T>(IEntity entity, Predicate<T> match) where T : IBuffDataComponent
        {
            if (!_entities.Contains(entity))
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
                for (var i = _buffMap[entity].Count - 1; i >= 0; i--)
                {
                    var buff = _buffMap[entity][i];
                    RemoveBuff(entity, buff);
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