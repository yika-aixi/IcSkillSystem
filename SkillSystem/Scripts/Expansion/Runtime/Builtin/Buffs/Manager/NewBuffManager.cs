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
    public class NewBuffManager:INewBuffManager
    {
        struct BuffPtrInfo
        {
            public IntPtr Ptr;

            public readonly int TypeIndex;

            public BuffPtrInfo(int typeIndex, IntPtr ptr) : this()
            {
                TypeIndex = typeIndex;
                Ptr = ptr;
            }
        }
        
        private FasterListThreadSafe<AIcBuffSystem> _systems;
        
        private Dictionary<BuffEntity, FasterListThreadSafe<BuffPtrInfo>> _buffMaps;

        public NewBuffManager()
        {
            _buffMaps = new Dictionary<BuffEntity, FasterListThreadSafe<BuffPtrInfo>>();
            _systems = new FasterListThreadSafe<AIcBuffSystem>();
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
//            _checkType<T>();
            
            var index = TypeManager.FindTypeIndex(typeof(T));

            if (!_buffMaps.TryGetValue(entity,out var buffs))
            {
                buffs = new FasterListThreadSafe<BuffPtrInfo>();
                _buffMaps.Add(entity,buffs);
            }
            
            Stopwatch stop = new Stopwatch();
            stop.Start();
            buffs.Add(new BuffPtrInfo(index,buff.ToPtr(false)));
            stop.Stop();
            Debug.Log(stop.Elapsed);
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
#if UNITY_EDITOR
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
            var index = TypeManager.FindTypeIndex(typeof(T));
            var buffPtr = buff.ToPtr();
            if (_buffMaps.TryGetValue(entity, out var buffs))
            {
                for (var i = buffs.Count - 1; i >= 0; i--)
                {
                    var buffPtrInfo = buffs[i];

                    if (buffPtrInfo.TypeIndex == index)
                    {
                        if (buffPtr == buffPtrInfo.Ptr)
                        {
                            buffPtr.Free();
                            buffPtrInfo.Ptr.Free();
                            buffs.RemoveAt(i);
                            _callDestroyBuffSystem(buff);                            
                            break;
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
            var index = TypeManager.FindTypeIndex(typeof(T));
            if (_buffMaps.TryGetValue(entity, out var buffs))
            {
                foreach (var ptrInfo in buffs)
                {
                    if (ptrInfo.TypeIndex == index)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int GetBuffCount<T>(BuffEntity entity) where T : IBuffDataComponent
        {
            var index = TypeManager.FindTypeIndex(typeof(T));
            
            int count = 0;
            
            if (_buffMaps.TryGetValue(entity, out var buffs))
            {
                foreach (var ptrInfo in buffs)
                {
                    if (ptrInfo.TypeIndex == index)
                    {
                        ++count;
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
    
    static class StructBuffEx
    {
        public static IntPtr ToPtr(this IBuffDataComponent self,bool deleteOld = true)
        {
            IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(self));
            Marshal.StructureToPtr(self,pnt,deleteOld);

            return pnt;
        }

        public static T ToBuff<T>(this IntPtr self) where T : IBuffDataComponent
        {
            return Marshal.PtrToStructure<T>(self);
        }
        
        public static void Free(this IntPtr self)
        {
            Marshal.FreeHGlobal(self);
        }
    }
}