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

        void AddBuff(IBuffDataComponent buff);
        
        IBuffDataComponent GetBuff(int index);

        void SetBuff(int index, IBuffDataComponent newBuff);
        
        IEnumerable<IBuffDataComponent> GetBuffs();

        void RemoveAt(int index);
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
    
    public class BuffManager_Struct:IStructBuffManager<IBuffSystem,IcSkSEntity>
    {
        public FasterReadOnlyList<IcSkSEntity> Entitys => _entitys.AsReadOnly();
        private IBuffList _currentBuffs;
        private FasterList<IcSkSEntity> _entitys;
        private Dictionary<IcSkSEntity, Dictionary<Type,IBuffList>> _buffMaps;
        private Action<IcSkSEntity, int> _onCreate;
        private Action<IcSkSEntity, int> _onDestroy;
        private Action _onUpdate;
        public BuffManager_Struct()
        {
            _entitys = new FasterList<IcSkSEntity>();
            _buffMaps = new Dictionary<IcSkSEntity, Dictionary<Type,IBuffList>>();
        }

        public IBuffManager<IBuffSystem,IcSkSEntity> AddBuffSystem(IBuffSystem buffSystem)
        {
            var type = buffSystem.GetType();

            switch (type)
            {
                case IBuffCreateSystem<IcSkSEntity> createSystem:
                    if (!_existHandle(_onCreate.GetInvocationList(),type))
                    {
                        _onCreate += createSystem.Create;
                    }
                    break;
                case IBuffUpdateSystem updateSystem:
                    if (!_existHandle(_onUpdate.GetInvocationList(),type))
                    {
                        _onUpdate += updateSystem.Execute;
                    }
                    break;
                case IBuffDestroySystem<IcSkSEntity> destroySystem:
                    if (!_existHandle(_onDestroy.GetInvocationList(),type))
                    {
                        _onCreate += destroySystem.Destroy;
                    }
                    break;
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
            _callSystem(entity,result.Count - 1, true);
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
                    result.RemoveAt(index);
                    _callSystem(entity, index, false);
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

        void IBuffManager<IBuffSystem, IcSkSEntity>.AddBuff<TBuff>(IcSkSEntity entity, in TBuff buff)
        {
            _addBuff(entity,typeof(TBuff),buff,true);
        }
        
        TBuff IBuffManager<IBuffSystem, IcSkSEntity>.GetCurrentBuffData<TBuff>(int index)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        TBuff IBuffManager<IBuffSystem, IcSkSEntity>.GetBuffData<TBuff>(IcSkSEntity entity, int index)
        {
            return _getBuffData<TBuff>(entity, index,true);
        }

        void IBuffManager<IBuffSystem, IcSkSEntity>.SetBuffData<TBuff>(IcSkSEntity entity, in TBuff buff, int index)
        {
            _setBuffData(entity,buff.GetType(), buff, index,true);
        }

        bool IBuffManager<IBuffSystem, IcSkSEntity>.RemoveBuff<TBuff>(IcSkSEntity entity, TBuff buff)
        {
            return _removeBuff(entity,buff.GetType(), buff,true);
        }

        bool IBuffManager<IBuffSystem, IcSkSEntity>.HasBuff<TBuff>(IcSkSEntity entity, TBuff buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        IEnumerable<TBuff> IBuffManager<IBuffSystem, IcSkSEntity>.GetBuffs<TBuff>(IcSkSEntity entity, TBuff condition)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        FasterReadOnlyList<TBuff> IBuffManager<IBuffSystem, IcSkSEntity>.GetBuffs<TBuff>(IcSkSEntity entity)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffManager<AIcStructBuffSystem<IcSkSEntity>, IcSkSEntity>)}");
        }

        int IBuffManager<IBuffSystem, IcSkSEntity>.GetBuffCount<TBuff>(IcSkSEntity entity)
        {
            return _getBuffCount<IBuffDataComponent>(entity);
        }

        #endregion
    }
}