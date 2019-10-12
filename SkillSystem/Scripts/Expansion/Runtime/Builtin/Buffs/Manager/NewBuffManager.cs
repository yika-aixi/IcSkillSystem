using System;
using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using Debug = UnityEngine.Debug;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs
{
    interface IBuffList
    {
        int Count { get; }
    }

    class BuffList<T>:FasterList<T>,IBuffList
    {
        public FasterReadOnlyList<T> Buffs => AsReadOnly();
    }

    class CreateAndDestroyEventInfo
    {
        public Action<IcSkSEntity, int> OnCreate;
        public Action<IcSkSEntity, int> OnDestroy;
    }
    
    public class NewBuffManager:IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>,IcSkSEntity>
    {
        public FasterReadOnlyList<IcSkSEntity> Entitys => _entitys.AsReadOnly();
        private IBuffList _currentBuffs;
        private FasterList<IcSkSEntity> _entitys;
        private Dictionary<IcSkSEntity, Dictionary<Type,IBuffList>> _buffMaps;
        private Action<IcSkSEntity, int> _onCreate;
        private Action<IcSkSEntity, int> _onDestroy;
        private Action _onUpdate;
        public NewBuffManager()
        {
            _entitys = new FasterList<IcSkSEntity>();
            _buffMaps = new Dictionary<IcSkSEntity, Dictionary<Type,IBuffList>>();
        }

        public INewBuffManager<AIcStructBuffSystem<IcSkSEntity>,IcSkSEntity> AddBuffSystem(AIcStructBuffSystem<IcSkSEntity> structBuffSystem)
        {
            if (_onCreate != null)
            {
                var type = structBuffSystem.GetType();
                foreach (var @delegate in _onCreate.GetInvocationList())
                {
                    if (@delegate.Target.GetType() == type)
                    {
#if UNITY_EDITOR
                        Debug.LogWarning($"{type} System already exists, skip");
#endif
                        return this;
                    }
                }
            }
            _onCreate += structBuffSystem.Create;
            _onDestroy += structBuffSystem.Destroy;
            _onUpdate += structBuffSystem.Execute;
            return this;
        }

        public void AddEntity(IcSkSEntity entity)
        {
            if (_entitys.Contains(entity))
            {
                return;
            }
            
            _entitys.Add(entity);
            
            _buffMaps.Add(entity,new Dictionary<Type, IBuffList>());
        }
        
        public void RemoveEntity(IcSkSEntity entity)
        {
            if (!_checkEntityExist(entity))
            {
                return;
            }
            
            _entitys.Remove(entity);

            _buffMaps.Remove(entity);
        }

        public void AddBuff<T>(IcSkSEntity entity,in T buff) where T : struct, IBuffDataComponent
        {
            _checkType<T>();
            if (!_checkEntityExist(entity))
            {
                return;
            }
            _addBuff(entity, buff);
        }

        private void _addBuff<T>(IcSkSEntity entity, T buff) where T : struct, IBuffDataComponent
        {
            BuffList<T> buffList;
            var type = typeof(T);

            var buffMap = _buffMaps[entity];

            if (!buffMap.TryGetValue(type, out var result))
            {
                buffList = new BuffList<T>();
                buffMap.Add(type, buffList);
            }
            else
            {
                buffList = (BuffList<T>) result;
            }

            buffList.Add(buff);
            _currentBuffs = buffList;
            _callSystem(entity,buffList.Count - 1, true);
        }

        /// <summary>
        /// Systme中查询
        /// </summary>
        /// <param name="index"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetCurrentBuffData<T>(int index) where T : struct, IBuffDataComponent
        {
            if (_currentBuffs.Count - 1 < index)
            {
                throw new IndexOutOfRangeException($"{typeof(T).Name} Buff Count :{_currentBuffs.Count},get index :{index}");
            }
            return ((BuffList<T>) _currentBuffs)[index];
        }
        
        public T GetBuffData<T>(IcSkSEntity entity, int index) where T : struct, IBuffDataComponent
        {
            if (!_checkEntityExist(entity))
            {
                throw new ArgumentException($"{entity.ID} entity not exist! Please Call {nameof(AddEntity)}.");
            }
            
            var type = typeof(T);
            var buffMap = _buffMaps[entity];

            if (!buffMap.TryGetValue(type, out var result))
            {
                throw new ArgumentException($"no {type.Name} Buff! Please Call {nameof(AddBuff)} or {nameof(SetBuffData)}.");
            }

            if (result.Count - 1 < index)
            {
                throw new IndexOutOfRangeException($"{type.Name} Buff Count :{result.Count},get index :{index}");
            }

            return ((BuffList<T>)result)[index];
        }

        /// <summary>
        /// 设置buff值,如果不存在指定类型的buff或索引超出就会进行添加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="buff"></param>
        /// <param name="index"></param>
        /// <typeparam name="T"></typeparam>
        public void SetBuffData<T>(IcSkSEntity entity, in T buff,int index) where T : struct, IBuffDataComponent
        {
            _checkType<T>();
            if (!_checkEntityExist(entity))
            {
                return;
            }
            var type = typeof(T);
            var buffMap = _buffMaps[entity];
            
            if (!buffMap.TryGetValue(type,out var result))
            {
                _addBuff(entity,buff);
                return;
            }
            
            BuffList<T> buffList = (BuffList<T>) result;

            if (index >= buffList.Count -1)
            {
                _addBuff(entity,buff);
                return;
            }

            buffList[index] = buff;
        }

        private void _callSystem(IcSkSEntity entity,int index,bool isCreate)
        {
            if (isCreate)
            {
                _onCreate?.Invoke(entity,index);
            }
            else
            {
                _onDestroy?.Invoke(entity,index);
            }
        }

        private bool _checkEntityExist(IcSkSEntity entity)
        {
            return _entitys.Contains(entity);
        }

        private static void _checkType<T>() where T : struct, IBuffDataComponent
        {
#if UNITY_EDITOR && IcSkillSystemDebug
            var type = typeof(T);

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var fieldInfo in fields)
            {
                IcCheck.True(fieldInfo.FieldType.IsValueType,$"{type.Name}.{fieldInfo.Name} not is Value Type.");
            }

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var propertyInfo in properties)
            {
                IcCheck.True(propertyInfo.PropertyType.IsValueType,$"{type.Name}.{propertyInfo.Name} not is Value Type.");
            }
#endif
        }

        public bool RemoveBuff<T>(IcSkSEntity entity, T buff) where T : struct, IBuffDataComponent
        {
            return _removeBuff(entity, buff);
        }

        private bool _removeBuff<T>(IcSkSEntity entity, T buff)
        {
            if (!_checkEntityExist(entity))
            {
                return false;
            }

            var buffMap = _buffMaps[entity];

            var type = typeof(T);
            if (buffMap.TryGetValue(type, out var result))
            {
                var buffList = (BuffList<T>) result;
                for (var index = buffList.Count - 1; index >= 0; index--)
                {
                    var bf = buffList[index];
                    if (bf.Equals(buff))
                    {
                        _currentBuffs = buffList;
                        buffList.RemoveAt(index);
                        _callSystem(entity, index, false);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasBuff<T>(IcSkSEntity entity,T buff) where T : struct, IBuffDataComponent
        {
            return _hasBuff(entity, typeof(T), buff);
        }

        /// <summary>
        /// box
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="buffType"></param>
        /// <returns></returns>
        public bool HasBuff(IcSkSEntity entity, Type buffType)
        {
            return _hasBuff<IBuffDataComponent>(entity, buffType, null);
        }

        /// <summary>
        /// box
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="buffType"></param>
        /// <param name="buff"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool HasBuff(IcSkSEntity entity, Type buffType, IBuffDataComponent buff)
        {
            return _hasBuff(entity, buffType, buff);
        }
        
        bool _hasBuff<T>(IcSkSEntity entity,Type type,T buff)
        {
            if (!_checkEntityExist(entity))
            {
                return false;
            }
            
            var buffMap = _buffMaps[entity];
            
            if (buffMap.TryGetValue(type,out var result))
            {
                var buffList = (BuffList<T>) result;
                
                if (buff.Equals(default))
                {
                    return true;
                }
                
                foreach (var bf in buffList)
                {
                    if (buff.Equals(bf))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public IEnumerable<T> GetBuffs<T>(IcSkSEntity entity,T condition) where T :struct, IBuffDataComponent
        {
            var buffs = GetBuffs<T>(entity);

            if (buffs.Count > 0)
            {
                return buffs.Where(x => x.Equals(condition));
            }
            
            return FasterReadOnlyList<T>.DefaultList;
        }
        
        public FasterReadOnlyList<T> GetBuffs<T>(IcSkSEntity entity) where T :struct, IBuffDataComponent
        {
            if (_checkEntityExist(entity))
            {
                var buffMap = _buffMaps[entity];
            
                if (buffMap.TryGetValue(typeof(T), out var result))
                {
                    return ((BuffList<T>)result).Buffs;
                }
            }
            
            return FasterReadOnlyList<T>.DefaultList;
        }

        /// <summary>
        /// 效率非常低,只建议在Editor下访问
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IEnumerable<IBuffDataComponent> GetAllBuff(IcSkSEntity entity)
        {
           if (!_checkEntityExist(entity))
           {
               return null;
           }

           List<IBuffDataComponent> buffs = new List<IBuffDataComponent>();
           
           foreach (var buffList1 in _buffMaps[entity].Values)
           {
               var buffList = (BuffList<IBuffDataComponent>) buffList1;
               
               buffs.AddRange(buffList.Buffs);
           }

           return buffs;
        }

        public int GetBuffCount<T>(IcSkSEntity entity) where T : struct,IBuffDataComponent
        {
            int count = 0;
            
            if (!_checkEntityExist(entity))
            {
                return count;
            }
            
            var buffMap = _buffMaps[entity];
            
            if (buffMap.TryGetValue(typeof(T), out var result))
            {
                count += result.Count;
            }

            return count;
        }
        
        public void Update()
        {
            _onUpdate?.Invoke();
        }

        #region Cover
        
        void INewBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>.AddBuff<TBuff>(IcSkSEntity entity, in TBuff buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }
        
        TBuff INewBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>.GetCurrentBuffData<TBuff>(int index)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        TBuff INewBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>.GetBuffData<TBuff>(IcSkSEntity entity, int index)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        void INewBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>.SetBuffData<TBuff>(IcSkSEntity entity, in TBuff buff, int index)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        bool INewBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>.RemoveBuff<TBuff>(IcSkSEntity entity, TBuff buff)
        {
            return _removeBuff(entity, buff);
        }

        bool INewBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>.HasBuff<TBuff>(IcSkSEntity entity, TBuff buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        IEnumerable<TBuff> INewBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>.GetBuffs<TBuff>(IcSkSEntity entity, TBuff condition)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        FasterReadOnlyList<TBuff> INewBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>.GetBuffs<TBuff>(IcSkSEntity entity)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        int INewBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>.GetBuffCount<TBuff>(IcSkSEntity entity)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        #endregion
    }
}