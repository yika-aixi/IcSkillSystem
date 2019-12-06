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
    public class BuffManager_Struct<TEntity>:IStructBuffManager<TEntity> where TEntity : IIcSkSEntity
    {
        public FasterReadOnlyList<TEntity> Entitys => _entitys.AsReadOnly();
        private IBuffList _currentBuffs;
        private FasterList<TEntity> _entitys;
        private Dictionary<TEntity, Dictionary<Type,IBuffList>> _buffMaps;
        private Dictionary<Type,List<IBuffCreateSystem<TEntity>>> _onCreateMap = new Dictionary<Type, List<IBuffCreateSystem<TEntity>>>();
        private Dictionary<Type,List<IBuffDestroySystem<TEntity>>> _onDestroyMap = new Dictionary<Type, List<IBuffDestroySystem<TEntity>>>();
        private event Action _onUpdate;
        public BuffManager_Struct()
        {
            _entitys = new FasterList<TEntity>();
            _buffMaps = new Dictionary<TEntity, Dictionary<Type,IBuffList>>();
        }

        public IStructBuffManager<TEntity> AddBuffSystem<TBuffType>(IBuffSystem buffSystem) where TBuffType : struct,IBuffDataComponent
        {
            var type = buffSystem.GetType();
            var buffType = typeof(TBuffType);
            if (buffSystem is IBuffCreateSystem<TEntity> createSystem)
            {
                if (!_onCreateMap.TryGetValue(buffType,out var actions))
                {
                    actions = new List<IBuffCreateSystem<TEntity>>();
                    _onCreateMap.Add(buffType,actions);
                }

                if (!_existHandle(actions,type))
                {
                    actions.Add(createSystem);
                }
            }

            if (buffSystem is IBuffUpdateSystem updateSystem)
            {
                if (_onUpdate == null || !_existHandle(_onUpdate.GetInvocationList(),type))
                {
                    _onUpdate += updateSystem.Execute;
                }
            }
            
            if (buffSystem is IBuffDestroySystem<TEntity> destroySystem)
            {
                if (!_onDestroyMap.TryGetValue(buffType,out var actions))
                {
                    actions = new List<IBuffDestroySystem<TEntity>>();
                    _onDestroyMap.Add(buffType,actions);
                }
                
                if (!_existHandle(actions,type))
                {
                    actions.Add(destroySystem);
                }
            }
            
            return this;
        }

        private bool _existHandle(Delegate[] getInvocationList, Type type)
        {
            foreach (var handle in getInvocationList)
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

        private bool _existHandle(IEnumerable<IBuffSystem> handles, Type type)
        {
            foreach (var handle in handles)
            {
                if (handle.GetType() == type)
                {
#if UNITY_EDITOR
                    Debug.LogWarning($"{type} System already exists, skip");
#endif
                    return true;
                }
            }

            return false;
        }

        public void AddEntity(TEntity entity)
        {
            if (_entitys.Contains(entity))
            {
                return;
            }
            
            _entitys.Add(entity);
            
            _buffMaps.Add(entity,new Dictionary<Type, IBuffList>());
        }
        
        public void RemoveEntity(TEntity entity)
        {
            if (!_checkEntityExist(entity))
            {
                return;
            }
            
            _entitys.Remove(entity);

            _buffMaps.Remove(entity);
        }

        public void AddBuff<T>(TEntity entity,in T buff) where T : struct, IBuffDataComponent
        {
            if (!_checkEntityExist(entity))
            {
                return;
            }
            
            _addBuff(entity,typeof(T), buff,false);
        }

#if UNITY_EDITOR
        private bool _createExecute;
#endif

        private void _addBuff<T>(TEntity entity,Type buffType, T buff,bool isBox)
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

#if UNITY_EDITOR
            _createExecute = true;
#endif
            _callSystem(entity, buffType, result.Count - 1, true);
#if UNITY_EDITOR
            _createExecute = false;
#endif
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
        
        public T GetBuffData<T>(TEntity entity, int index) where T : struct, IBuffDataComponent
        {
            return _getBuffData<T>(entity, index);
        }

        private T _getBuffData<T>(TEntity entity, int index,bool isBox = false)
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
        public void SetBuffData<T>(TEntity entity, in T buff,int index) where T : struct, IBuffDataComponent
        {
            var type = typeof(T);
            _setBuffData(entity, type,buff, index);
        }
        
        private void _setBuffData<T>(TEntity entity,Type buffType, in T buff,int index,bool isBox = false)
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
#if UNITY_EDITOR
        private Type _lastExecuteCreateBuffSystem;
#endif
        private void _callSystem(TEntity entity,Type buffType,int index,bool isCreate)
        {
            if (isCreate)
            {
                if (_onCreateMap.TryGetValue(buffType,out var action))
                {
                    var count = action.Count;
                    for (var i = 0; i < count; i++)
                    {
#if UNITY_EDITOR
                        _lastExecuteCreateBuffSystem = action[i].GetType();        
#endif
                        action[i].Create(entity, index);
                    }
                }
            }
            else
            {
                if (_onDestroyMap.TryGetValue(buffType,out var action))
                {
                    var count = action.Count;
                    
                    for (var i = 0; i < count; i++)
                    {
                        action[i].Destroy(entity, index);
                    }
                }
            }
        }

        private bool _checkEntityExist(TEntity entity)
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

        public bool RemoveBuff<T>(TEntity entity, T buff) where T : struct, IBuffDataComponent
        {
            var type = typeof(T);

            return _removeBuff(entity,type, buff);
        }

        private bool _removeBuff<T>(TEntity entity,Type buffType, T buff,bool isBox = false)
        {
            if (!_checkEntityExist(entity))
            {
                return false;
            }

#if UNITY_EDITOR
            if (_createExecute)
            {
                Debug.LogError($"{_lastExecuteCreateBuffSystem} Remove buff,Subsequent `Create System` will be abnormal, please change the System to the last execution or not add the `{buffType}` type buff `Create System` after this System");
            }
#endif
            var buffMap = _buffMaps[entity];

            if (buffMap.TryGetValue(buffType, out var result))
            {
                BuffList<T> buffList = null;
                
                if (!isBox)
                {
                    buffList = (BuffList<T>) result;
                }

                var count = result.Count;
                for (var index = count - 1; index >= 0; index--)
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
                    break;
                }
            }

            return false;
        }

        public bool HasBuff<T>(TEntity entity,T buff) where T : struct, IBuffDataComponent
        {
            return _hasBuff(entity, typeof(T), buff);
        }

        /// <summary>
        /// box
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="buffType"></param>
        /// <returns></returns>
        public bool HasBuff(TEntity entity, Type buffType)
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
        public bool HasBuff(TEntity entity, Type buffType, IBuffDataComponent buff)
        {
            return _hasBuff(entity, buffType, buff);
        }
        
        bool _hasBuff<T>(TEntity entity,Type type,T buff)
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
        public NativeArray<BuffDataInfo<T>> GetBuffsCondition<T>(TEntity entity, Func<T,bool> condition) where T :struct, IBuffDataComponent
#else
        public FasterList<BuffDataInfo<T>> GetBuffsCondition<T>(TEntity entity, Func<T,bool> condition) where T :struct, IBuffDataComponent
#endif
        {
            var buffs = _getBuffs<T>(entity);

            if (buffs == null)
            {
#if ENABLE_MANAGED_JOBS
               return new NativeArray<BuffDataInfo<T>>(0,Allocator.Temp,NativeArrayOptions.UninitializedMemory);
#else
                return null;
#endif
            }

            int count = condition == null ? buffs.Count : buffs.Count(condition);

#if ENABLE_MANAGED_JOBS
            var result = new NativeArray<BuffDataInfo<T>>(count,Allocator.Temp,NativeArrayOptions.UninitializedMemory);
            count = 0;
#else
            FasterList<BuffDataInfo<T>> result = new FasterList<BuffDataInfo<T>>(count);
#endif
            for (var i = 0; i < buffs.Count; i++)
            {
                var buff = buffs[i];
                
                if (condition?.Invoke(buff) ?? true)
                {
#if ENABLE_MANAGED_JOBS
                    try
                    {
                        result[count] = new BuffDataInfo<T>(i,buff);
                        count++;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        //已经找到所有,结束后续
                        break;
                    }
#else
                    if (result.Count == result.ToArrayFast().Length)
                    {
                        //已经找到所有,结束后续
                        break;
                    }
                    result.Add(new BuffDataInfo<T>(i,buff));
#endif
                }
            }
            
            return result;
        }
        
#if ENABLE_MANAGED_JOBS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public NativeArray<int> GetBuffsCondition<T>(TEntity entity, Func<T,bool> condition,out FasterList<T> outBuffs) where T :struct, IBuffDataComponent
#else
        public FasterList<int> GetBuffsCondition<T>(TEntity entity, Func<T,bool> condition,out FasterList<T> outBuffs) where T :struct, IBuffDataComponent
#endif
        {
            var buffs = _getBuffs<T>(entity);
           
            outBuffs = buffs;
           
            if (buffs == null)
            {
#if ENABLE_MANAGED_JOBS
                return new NativeArray<int>(0,Allocator.Temp,NativeArrayOptions.UninitializedMemory);
#else
                return null;
#endif
            }

            int count = condition == null ? buffs.Count : buffs.Count(condition);

#if ENABLE_MANAGED_JOBS
            var result = new NativeArray<int>(count,Allocator.Temp,NativeArrayOptions.UninitializedMemory);
            count = 0;
#else
            FasterList<int> result = new FasterList<int>(count);
#endif
            for (var i = 0; i < buffs.Count; i++)
            {
                var buff = buffs[i];
                
                if (condition?.Invoke(buff) ?? true)
                {
#if ENABLE_MANAGED_JOBS
                    try
                    {
                        result[count] = i;
                        count++;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        //已经找到所有,结束后续
                        break;
                    }
#else
                    if (result.Count == result.ToArrayFast().Length)
                    {
                        //已经找到所有,结束后续
                        break;
                    }
                    result.Add(i);
#endif
                }
            }
            
            return result;
        }
        
        public FasterReadOnlyList<T> GetBuffs<T>(TEntity entity) where T :struct, IBuffDataComponent
        {
            var buffs = _getBuffs<T>(entity);

            if (buffs == null)
            {
                return FasterReadOnlyList<T>.DefaultList;
            }

            return buffs.AsReadOnly();
        }
        
        private FasterList<T> _getBuffs<T>(TEntity entity) where T :struct, IBuffDataComponent
        {
            if (_checkEntityExist(entity))
            {
                var buffMap = _buffMaps[entity];
            
                if (buffMap.TryGetValue(typeof(T), out var result))
                {
                    return ((BuffList<T>)result);
                }
            }

            return null;
        }

        /// <summary>
        /// 效率非常低,只建议在Editor下访问
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IEnumerable<IBuffDataComponent> GetAllBuff(TEntity entity)
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

        public int GetBuffCount<T>(TEntity entity) where T : struct,IBuffDataComponent
        {
            return _getBuffCount<T>(entity);
        }

        private int _getBuffCount<T>(TEntity entity)
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
        
        [Obsolete("use -> `GetBuffsCondition`")]
        public IEnumerable<T> GetBuffs<T>(TEntity entity,Func<T,bool> condition) where T :IBuffDataComponent
        {
            throw new NotImplementedException($"please use {nameof(GetBuffsCondition)}.");
        }

        /// <summary>
        /// 不受支持
        /// </summary>
        /// <param name="buffSystem"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Obsolete("please use -> AddBuffSystem<TBuffType>()")]
        IBuffManager<TEntity> IBuffManager<TEntity>.AddBuffSystem<TBuff>(IBuffSystem buffSystem)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<TEntity>)}");
        }

        void IBuffManager<TEntity>.AddBuff<TBuff>(TEntity entity, in TBuff buff)
        {
            _addBuff(entity,typeof(TBuff),buff,true);
        }
        
        TBuff IBuffManager<TEntity>.GetCurrentBuffData<TBuff>(int index)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<TEntity>)}");
        }

        TBuff IBuffManager<TEntity>.GetBuffData<TBuff>(TEntity entity, int index)
        {
            return _getBuffData<TBuff>(entity, index,true);
        }

        void IBuffManager<TEntity>.SetBuffData<TBuff>(TEntity entity, in TBuff buff, int index)
        {
            _setBuffData(entity,buff.GetType(), buff, index,true);
        }

        bool IBuffManager<TEntity>.RemoveBuff<TBuff>(TEntity entity, TBuff buff)
        {
            return _removeBuff(entity,buff.GetType(), buff,true);
        }

        bool IBuffManager<TEntity>.HasBuff<TBuff>(TEntity entity, TBuff buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<TEntity>)}");
        }

        [Obsolete("use IStructBuffManager.GetBuffs<struct>(TEntity)")]
        FasterReadOnlyList<TBuff> IBuffManager<TEntity>.GetBuffs<TBuff>(TEntity entity)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<TEntity>)}");
        }

        int IBuffManager<TEntity>.GetBuffCount<TBuff>(TEntity entity)
        {
            return _getBuffCount<IBuffDataComponent>(entity);
        }

        #endregion
    }
}