using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Buffs.Exceptions;
using Debug = UnityEngine.Debug;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs
{
    interface IBuffList
    {
        Type ValueType{get;}
        
        int Count { get; }
    }

    class BuffList<T>:FasterList<T>,IBuffList
    {
        public Type ValueType { get; } = typeof(T);
    }
    
    public class NewBuffManager:INewBuffManager
    {
        private FasterList<AIcBuffSystem> _systems;
        
        private Dictionary<BuffEntity, List<IBuffList>> _buffMaps;

        public NewBuffManager()
        {
            _buffMaps = new Dictionary<BuffEntity, List<IBuffList>>();
            _systems = new FasterList<AIcBuffSystem>();
        }

        public INewBuffManager AddBuffSystem(AIcBuffSystem buffSystem)
        {
#if UNITY_EDITOR
            if (_systems.Contains(buffSystem))
            {
                Debug.LogWarning($"{buffSystem.GetType()} System already exists, skip");
                return this;
            }
#endif
            _systems.Add(buffSystem);
            
            return this;
        }

        public void AddBuff<T>(BuffEntity entity, T buff) where T : struct, IBuffDataComponent
        {
            _checkType<T>();
            BuffList<T> buffList = null;
            if (!_buffMaps.TryGetValue(entity,out var buffs))
            {
                buffs = new List<IBuffList>();
                buffList = new BuffList<T>();
                buffs.Add(buffList);
                _buffMaps.Add(entity,buffs);
            }
            else
            {
                bool hit = false;
                
                foreach (var list in buffs)
                {
                    if (list.ValueType == typeof(T))
                    {
                        hit = true;
                        buffList = (BuffList<T>) list;
                        break;
                    }
                }

                if (!hit)
                {
                    buffList = new BuffList<T>();
                    buffs.Add(buffList);   
                }
            }
            
            buffList.Add(buff);
            
            //todo Create System
            
            foreach (var buffSystem in _systems)
            {
                if (buffSystem.Filter())
                {
                    buffSystem.Create();
                }
            }
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

        public void RemoveBuff<T>(BuffEntity entity, T buff) where T : struct, IBuffDataComponent
        {
            if (_buffMaps.TryGetValue(entity, out var result))
            {
                foreach (var list in result)
                {
                    if (list.ValueType == typeof(T))
                    {
                        BuffList<T> buffList = (BuffList<T>) list;

                        for (var index = buffList.Count - 1; index >= 0; index--)
                        {
                            var bf = buffList[index];
                            if (bf.Equals(buff))
                            {
                                buffList.RemoveAt(index);
                                _callDestroyBuffSystem(buff);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void _callDestroyBuffSystem<T>(T buff) where T : struct, IBuffDataComponent
        {
            //todo System
            foreach (var buffSystem in _systems)
            {
                if (buffSystem.Filter())
                {
                    buffSystem.Destroy();
                }
            }
        }

        //todo 暂时只有类型判断
        public bool HasBuff<T>(BuffEntity entity,T buff) where T : struct, IBuffDataComponent
        {
            if (_buffMaps.TryGetValue(entity, out var buffs))
            {
                foreach (var ptrInfo in buffs)
                {
                    if (ptrInfo.ValueType == typeof(T))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int GetBuffCount<T>(BuffEntity entity) where T : IBuffDataComponent
        {
            int count = 0;
            
            if (_buffMaps.TryGetValue(entity, out var result))
            {
                foreach (var buffList in result)
                {
                    if (buffList.ValueType == typeof(T))
                    {
                        count += buffList.Count;
                    }
                }
            }

            return count;
        }
        
        public void Update()
        {
            //todo Update System
        }
    }
}