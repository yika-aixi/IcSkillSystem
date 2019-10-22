using System;
using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
#if ENABLE_MANAGED_JOBS
using Unity.Collections;
#endif
using Debug = UnityEngine.Debug;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs
{
    interface IBuffList
    {
        int Count { get; }

        void AddBuff(IBuffDataComponent buff);
        
        IBuffDataComponent GetBuff(int index);

        void SetBuff(int index, IBuffDataComponent newBuff);
        
        IEnumerable<IBuffDataComponent> GetBuffs();

        void RemoveAt(int index);
    }

    public struct BuffDataInfo<T> where T : struct,IBuffDataComponent
    {
        public int Index { get; }
        public T Buff { get; }

        public BuffDataInfo(in int index,in T buff):this()
        {
            Index = index;
            Buff = buff;
        }
    }

    class BuffList<T>:FasterList<T>,IBuffList
    {
        public FasterReadOnlyList<T> Buffs => AsReadOnly();

        public void AddBuff(IBuffDataComponent buff)
        {
            Add((T) buff);
        }

        public IBuffDataComponent GetBuff(int index)
        {
            return (IBuffDataComponent)this[index];
        }

        public void SetBuff(int index, IBuffDataComponent newBuff)
        {
            this[index] = (T) newBuff;
        }
        
        public IEnumerable<IBuffDataComponent> GetBuffs()
        {
            return Buffs.Select(x=>(IBuffDataComponent) x);
        }
    }
    
//    public struct QueryResult
//    {
//        Dictionary<>
//    }
//    
    public class BuffManager_Struct:IStructBuffManager<IcSkSEntity>
    {
        public FasterReadOnlyList<IcSkSEntity> Entitys => _entitys.AsReadOnly();
        private IBuffList _currentBuffs;
        private FasterList<IcSkSEntity> _entitys;
        private Dictionary<IcSkSEntity, Dictionary<Type,IBuffList>> _buffMaps;
        private Dictionary<Type,Action<IcSkSEntity, int>> _onCreateMap = new Dictionary<Type, Action<IcSkSEntity, int>>();
        private Dictionary<Type,Action<IcSkSEntity, int>> _onDestroyMap = new Dictionary<Type, Action<IcSkSEntity, int>>();
        private Action _onUpdate;
        public BuffManager_Struct()
        {
            _entitys = new FasterList<IcSkSEntity>();
            _buffMaps = new Dictionary<IcSkSEntity, Dictionary<Type,IBuffList>>();
        }

        public IStructBuffManager<IcSkSEntity> AddBuffSystem<TBuffType>(IBuffSystem buffSystem) where TBuffType : struct,IBuffDataComponent
        {
            var type = buffSystem.GetType();
            var buffType = typeof(TBuffType);
            if (buffSystem is IBuffCreateSystem<IcSkSEntity,TBuffType> createSystem)
            {
                if (!_onCreateMap.ContainsKey(buffType))
                {
                    _onCreateMap.Add(buffType,createSystem.Create);
                }
                else
                {
                    var action = _onCreateMap[buffType];
                    
                    if (!_existHandle(action.GetInvocationList(),type))
                    {
                        _onCreateMap[buffType] += createSystem.Create;
                    }
                }
            }

            if (buffSystem is IBuffUpdateSystem updateSystem)
            {
                if (_onUpdate == null || !_existHandle(_onUpdate.GetInvocationList(),type))
                {
                    _onUpdate += updateSystem.Execute;
                }
            }
            
            if (buffSystem is IBuffDestroySystem<IcSkSEntity,TBuffType> destroySystem)
            {
                if (!_onDestroyMap.ContainsKey(buffType))
                {
                    _onDestroyMap.Add(buffType,destroySystem.Destroy);
                }
                else
                {
                    var action = _onDestroyMap[buffType];
                    
                    if (!_existHandle(action.GetInvocationList(),type))
                    {
                        _onDestroyMap[buffType] += destroySystem.Destroy;
                    }
                }
            }
            
            return this;
        }

        private bool _existHandle(Delegate[] handles, Type type)
        {
            foreach (var handle in handles)
            {
                if (handle.Target.GetType() == type)
                {
#if UNITY_EDITOR
                    Debug.LogWarning($"{type} System already exists, skip");
#endif
                    return true;
                }
            }

            return false;
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
            if (!_checkEntityExist(entity))
            {
                return;
            }
            
            _addBuff(entity,typeof(T), buff,false);
        }

        private void _addBuff<T>(IcSkSEntity entity,Type buffType, T buff,bool isBox)
        {
            _checkType<T>();
            
            BuffList<T> buffList;

            var buffMap = _buffMaps[entity];

            if (!buffMap.TryGetValue(buffType, out var result))
            {
                if (isBox)
                {
                    Debug.LogError($"Add Buff {buffType} is appear box ing. If it is not caused by Editor Tools, please handle it.");
                }
                
                result = new BuffList<T>();
                
                buffMap.Add(buffType, result);
            }
            
            if (!isBox)
            {
                buffList = (BuffList<T>) result;
                buffList.Add(buff);
            }
            else
            {
                result.AddBuff((IBuffDataComponent) buff);
            }

            _currentBuffs = result;
            _callSystem(entity,buffType,result.Count - 1, true);
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
            return _getBuffData<T>(entity, index);
        }

        private T _getBuffData<T>(IcSkSEntity entity, int index,bool isBox = false)
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

            return isBox ? (T) result.GetBuff(index) : ((BuffList<T>) result)[index];
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
            var type = typeof(T);
            _setBuffData(entity, type,buff, index);
        }
        
        private void _setBuffData<T>(IcSkSEntity entity,Type buffType, in T buff,int index,bool isBox = false)
        {
            if (!_checkEntityExist(entity))
            {
                return;
            }
            
            var buffMap = _buffMaps[entity];
            
            if (!buffMap.TryGetValue(buffType,out var result))
            {
                _addBuff(entity,buffType,buff,isBox);
                return;
            }
            

            if (index > result.Count -1)
            {
                _addBuff(entity,buffType,buff,isBox);
                return;
            }

            if (!isBox)
            {
                BuffList<T> buffList = (BuffList<T>) result;

                buffList[index] = buff;
            }
            else
            {
                result.SetBuff(index,(IBuffDataComponent) buff);
            }
           
        }

        private void _callSystem(IcSkSEntity entity,Type buffType,int index,bool isCreate)
        {
            if (isCreate)
            {
                if (_onCreateMap.TryGetValue(buffType,out var action))
                {
                    action(entity,index);
                }
            }
            else
            {
                if (_onDestroyMap.TryGetValue(buffType,out var action))
                {
                    action(entity,index);
                }
            }
        }

        private bool _checkEntityExist(IcSkSEntity entity)
        {
            return _entitys.Contains(entity);
        }

        private static void _checkType<T>()
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
            var type = typeof(T);

            return _removeBuff(entity,type, buff);
        }

        private bool _removeBuff<T>(IcSkSEntity entity,Type buffType, T buff,bool isBox = false)
        {
            if (!_checkEntityExist(entity))
            {
                return false;
            }

            var buffMap = _buffMaps[entity];

            if (buffMap.TryGetValue(buffType, out var result))
            {
                BuffList<T> buffList = null;
                
                if (!isBox)
                {
                    buffList = (BuffList<T>) result;
                }
                
                for (var index = result.Count - 1; index >= 0; index--)
                {
                    if (!isBox)
                    {
                        var bf = buffList[index];
                        if (!bf.Equals(buff))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (!result.GetBuff(index).Equals(buff))
                        {
                            continue;
                        }
                    }
                    
                    _currentBuffs = result;
                    _callSystem(entity,buffType, index, false);
                    result.RemoveAt(index);
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

#if ENABLE_MANAGED_JOBS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public NativeArray<BuffDataInfo<T>> GetBuffsCondition<T>(IcSkSEntity entity, Func<T,bool> condition) where T :struct, IBuffDataComponent
#else
        public FasterList<BuffDataInfo<T>> GetBuffsCondition<T>(IcSkSEntity entity, Func<T,bool> condition) where T :struct, IBuffDataComponent
#endif
        {
            var buffs = GetBuffs<T>(entity);

            if (buffs.Count == 0)
            {
#if ENABLE_MANAGED_JOBS
               return new NativeArray<BuffDataInfo<T>>(0,Allocator.Temp,NativeArrayOptions.UninitializedMemory);
#else
                return null;
#endif
            }

#if ENABLE_MANAGED_JOBS
            var result = new NativeArray<BuffDataInfo<T>>(buffs.Count,Allocator.Temp,NativeArrayOptions.UninitializedMemory);
#else
            FasterList<BuffDataInfo<T>> result = new FasterList<BuffDataInfo<T>>(buffs.Count);
#endif
            for (var i = 0; i < buffs.Count; i++)
            {
                var buff = buffs[i];

                if (condition?.Invoke(buff) ?? true)
                {
#if ENABLE_MANAGED_JOBS
                        result[i] = new BuffDataInfo<T>(i,buff);
#else
                    result.Add(new BuffDataInfo<T>(i,buff));
#endif
                }
            }
            
            return result;
        }

        [Obsolete("use -> `GetBuffsCondition`")]
        public IEnumerable<T> GetBuffs<T>(IcSkSEntity entity,T condition) where T :IBuffDataComponent
        {
            throw new NotImplementedException($"please use {nameof(GetBuffsCondition)}.");
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
               var buffList = buffList1;
               
               buffs.AddRange(buffList.GetBuffs());
           }

           return buffs;
        }

        public int GetBuffCount<T>(IcSkSEntity entity) where T : struct,IBuffDataComponent
        {
            return _getBuffCount<T>(entity);
        }

        private int _getBuffCount<T>(IcSkSEntity entity)
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

        /// <summary>
        /// 不受支持
        /// </summary>
        /// <param name="buffSystem"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Obsolete("please use -> AddBuffSystem<TBuffType>()")]
        public IBuffManager<IcSkSEntity> AddBuffSystem(IBuffSystem buffSystem)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<IcSkSEntity>)}");
        }

        void IBuffManager<IcSkSEntity>.AddBuff<TBuff>(IcSkSEntity entity, in TBuff buff)
        {
            _addBuff(entity,typeof(TBuff),buff,true);
        }
        
        TBuff IBuffManager<IcSkSEntity>.GetCurrentBuffData<TBuff>(int index)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<IcSkSEntity>)}");
        }

        TBuff IBuffManager<IcSkSEntity>.GetBuffData<TBuff>(IcSkSEntity entity, int index)
        {
            return _getBuffData<TBuff>(entity, index,true);
        }

        void IBuffManager<IcSkSEntity>.SetBuffData<TBuff>(IcSkSEntity entity, in TBuff buff, int index)
        {
            _setBuffData(entity,buff.GetType(), buff, index,true);
        }

        bool IBuffManager<IcSkSEntity>.RemoveBuff<TBuff>(IcSkSEntity entity, TBuff buff)
        {
            return _removeBuff(entity,buff.GetType(), buff,true);
        }

        bool IBuffManager<IcSkSEntity>.HasBuff<TBuff>(IcSkSEntity entity, TBuff buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<IcSkSEntity>)}");
        }

        [Obsolete("use IStructBuffManager<IcSkSEntity>.GetBuffs<struct>(IcSkSEntity)")]
        FasterReadOnlyList<TBuff> IBuffManager<IcSkSEntity>.GetBuffs<TBuff>(IcSkSEntity entity)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<IcSkSEntity>)}");
        }

        int IBuffManager<IcSkSEntity>.GetBuffCount<TBuff>(IcSkSEntity entity)
        {
            return _getBuffCount<IBuffDataComponent>(entity);
        }

        #endregion
    }
}