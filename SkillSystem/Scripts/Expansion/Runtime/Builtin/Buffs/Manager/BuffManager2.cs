//Create: Icarus
//ヾ(•ω•`)o
//2020-09-16 05:48
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using System;
using System.Collections.Generic;
using System.Threading;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs
{
    public class BuffManager2
    {
        interface IBuffChunkWeak
        {
            void         Update();
            void         RemoveAllBuff();
            
            BuffManager2 BuffM2 { get; set; }

            IIcSkSEntity Entity { get; set; }
        }
        
        class BuffChunk<T>:IBuffChunkWeak where T : unmanaged,IBuffData
        {
            FasterList<T> _buffs = new FasterList<T>();

            private Queue<int> _addQ = new Queue<int>();

            struct RemoveBuffInfo
            {
                public static RemoveBuffInfo Null = new RemoveBuffInfo(default,-1);
                
                public        T Buff;

                public int Index;

                public RemoveBuffInfo(T buff, int index)
                {
                    Buff  = buff;
                    Index = index;
                }
            }
            
            FasterList<RemoveBuffInfo> _removeQ = new FasterList<RemoveBuffInfo>();
            
            private T[] _fastAr => _buffs.ToArrayFast();

            private bool _isRemove;
            public void Update()
            {
                int count;

                if (_isRemove)
                {
                    var fastR = _removeQ.ToArrayFast();
                    count = fastR.Length;
                    for (int i = count - 1; i >= 0; i--)
                    {
                        var removeBuffInfo = fastR[i];

                        if (removeBuffInfo.Index == -1)
                        {
                            continue;
                        }

                        _onDestroy(this, _fastAr[i]);
                        _buffs.RemoveAt(removeBuffInfo.Index);

                        fastR[i] = RemoveBuffInfo.Null;
                    }

                    _isRemove = false;
                }
                
                count     = _addQ.Count;

                for (int i = 0; i < count; i++)
                {
                    _onCreateBuff(this, _addQ.Dequeue());
                }
                
                count = _buffs.Count;

                for (var i = 0; i < count; i++)
                {
                    _onUpdate(this, i);
                }
            }

            public BuffManager2 BuffM2 { get; set; }
            public IIcSkSEntity Entity { get; set; }

            public void AddBuff(in T buff)
            {
                SpinLock sl        = new SpinLock();
                bool     lockState = false;

                try
                {
                    sl.Enter(ref lockState);
                    
                    _addQ.Enqueue(_buffs.Count);
                
                    _buffs.AddIn(buff);
                    _removeQ.AddRef(ref RemoveBuffInfo.Null);
                }
                finally
                {
                    if (lockState)
                    {
                        sl.Exit();
                    }
                }
            }

            public void SetBuff(in T newBuff, int index)
            {
                if (index < 0 || index >= _buffs.Count)
                {
                    return;
                }

                _fastAr[index] = newBuff;
            }

            public void RemoveBuff(int index)
            {
                if (index < 0 || index >= _buffs.Count)
                {
                    return;
                }

                _isRemove = true;
                SpinLock sl        = new SpinLock();
                bool     lockState = false;

                try
                {
                    sl.Enter(ref lockState);
                    _removeQ.ToArrayFast()[index] = new RemoveBuffInfo(_fastAr[index], index);
                }
                finally
                {
                    if (lockState)
                    {
                        sl.Exit();
                    }
                }
            }

            public bool GetBuff(int index,out T buff)
            {
                var count = _buffs.Count;

                if (index < 0 || index >= count)
                {
                    buff = default;
                    return false;
                }

                buff = _fastAr[index];

                return true;
            }
            
            public void RemoveAllBuff()
            {
                var count = _buffs.Count;
                
                for (var index = count - 1; index >= 0; index--)
                {
                    RemoveBuff(index);
                }
            }
        }
        
        Dictionary<Type, IBuffChunkWeak> _buffChunk = new Dictionary<Type, IBuffChunkWeak>();

        private IEnumerable<IBuffChunkWeak> _chunk => _buffChunk.Values;
        
        public void Update()
        {
            foreach (var chunkWeak in _chunk)
            {
                chunkWeak.Update();
            }
        }

        public void AddBuff<T>(T buff, IIcSkSEntity entity) where T : unmanaged,IBuffData
        {
            BuffChunk<T> chunke;
            if (!_buffChunk.TryGetValue(typeof(T), out var chunkWeak))
            {
                chunke = new BuffChunk<T>();
                _buffChunk.Add(typeof(T), chunke);
            }
            else
            {
                chunke = (BuffChunk<T>) chunkWeak;
            }
            
            chunke.Entity = entity;
            chunke.AddBuff(buff);
        }

        public void SetBuff<T>(in T newBuff, int index) where T : unmanaged,IBuffData
        {
            if (_buffChunk.TryGetValue(typeof(T), out var chunkWeak))
            {
                BuffChunk<T> chunke = (BuffChunk<T>) chunkWeak;

                chunke.SetBuff(newBuff, index);
            }
        }
        
        public void RemoveBuff<T>(int index) where T : unmanaged,IBuffData
        {
            if (_buffChunk.TryGetValue(typeof(T), out var chunkWeak))
            {
                BuffChunk<T> chunke = (BuffChunk<T>) chunkWeak;
                
                chunke.RemoveBuff(index);
            }
        }

        public bool GetBuff<T>(int index, out T buff) where T : unmanaged,IBuffData
        {
            if (_buffChunk.TryGetValue(typeof(T), out var chunkWeak))
            {
                BuffChunk<T> chunke = (BuffChunk<T>) chunkWeak;

                return chunke.GetBuff(index, out buff);
            }

            buff = default;
            return false;
        }

        public void RemoveAllBuff()
        {
            foreach (var buffChunkWeak in _buffChunk)
            {
                buffChunkWeak.Value.RemoveAllBuff();
            }

            _buffChunk.Clear();
        }
        
        private static Dictionary<IIcSkSEntity, BuffManager2> _buffManager2s = new Dictionary<IIcSkSEntity, BuffManager2>();

        public static void Tick()
        {
            foreach (var buffManager2 in _buffManager2s.Values)
            {
                buffManager2.Update();
            }
        }
        
        public static void AddBuff<T>(IIcSkSEntity entity, T buff) where  T : unmanaged,IBuffData
        {
            if (!_buffManager2s.TryGetValue(entity, out var buffM))
            {
                buffM = new BuffManager2();

                _buffManager2s.Add(entity, buffM);
            }
            
            buffM.AddBuff(buff, entity);
        }

        public static void SetBuff<T>(IIcSkSEntity entity, int index, T buff) where  T : unmanaged, IBuffData
        {
            if (_buffManager2s.TryGetValue(entity, out var buffM))
            {
                buffM.SetBuff(buff, index);
            }
        }

        public static void RemoveBuff<T>(IIcSkSEntity entity, int index) where  T : unmanaged,IBuffData
        {
            if (_buffManager2s.TryGetValue(entity, out var buffM))
            {
                buffM.RemoveBuff<T>(index);
            }
        }
        
        public static void RemoveEntity(IIcSkSEntity entity)
        {
            if (_buffManager2s.TryGetValue(entity, out var buffM))
            {
                buffM.RemoveAllBuff();
            }

            _buffManager2s.Remove(entity);
        }

        public static bool GetBuff<T>(IIcSkSEntity entity, int index,out T buff) where T : unmanaged,IBuffData
        {
            if (_buffManager2s.TryGetValue(entity, out var buffM))
            {
                if (buffM.GetBuff(index, out buff))
                {
                    return true;
                }
            }

            buff = default;
            
            return false;
        }
        
        public interface IBuffCreateSystemNew<T> : IBuffSystem where T : unmanaged, IBuffData
        {
            void Create(IIcSkSEntity entity, int index);
        }
        
        public interface IBuffUpdateSystemNew<T> : IBuffSystem where T : unmanaged, IBuffData
        {
            void Update(IIcSkSEntity entity, int index);
        }
        
        public interface IBuffDestroySystemNew<T> : IBuffSystem where T : unmanaged, IBuffData
        {
            void Destroy(IIcSkSEntity entity, T buff);
        }

        // private static Dictionary<Type ,List<IBuffUpdateSystem>> _updateS = new Dictionary<Type, List<IBuffUpdateSystem>>();
        //
        // private static Dictionary<Type ,List<IBuffCreateSystem>> _createS = new Dictionary<Type, List<IBuffCreateSystem>>();
        //
        // private static Dictionary<Type ,List<IBuffDestroySystem>> _destoryS = new  Dictionary<Type, List<IBuffDestroySystem>>();

        private static FasterList<IBuffSystem> _systems = new FasterList<IBuffSystem>();
        
        static void _onCreateBuff<T>(BuffChunk<T> buffChunk, int index) where T : unmanaged, IBuffData
        {
            var count = _systems.Count;
            // var type  = typeof(T);
            
            // if (_createS.TryGetValue(type, out var systems))
            {
                for (var i = 0; i < count; i++)
                {
                    var system = _systems[i];

                    if (system is IBuffCreateSystemNew<T> createSystemNew)
                    {
                        createSystemNew.Create(buffChunk.Entity, index);
                    }
                    
                    // system.Create(buffChunk.Entity, index);
                }
            }
        }

        static void _onUpdate<T>(BuffChunk<T> buffChunk, int index) where T : unmanaged, IBuffData
        {
            var count = _systems.Count;
            for (var i = 0; i < count; i++)
            {
                var system = _systems[i];

                if (system is IBuffUpdateSystemNew<T> createSystemNew)
                {
                    createSystemNew.Update(buffChunk.Entity, index);
                }
                    
                // system.Create(buffChunk.Entity, index);
            }
        }

        static void _onDestroy<T>(BuffChunk<T> buffChunk,in T buff) where T : unmanaged, IBuffData
        {
            var count = _systems.Count;
            for (var i = 0; i < count; i++)
            {
                var system = _systems[i];

                if (system is IBuffDestroySystemNew<T> createSystemNew)
                {
                    createSystemNew.Destroy(buffChunk.Entity, buff);
                }
                    
                // system.Create(buffChunk.Entity, index);
            }
        }

        public static void AddSystem(IBuffSystem buffSystem)
        {
            // var type = typeof(IBuffSystem);
            //
            // if (buffSystem is IBuffCreateSystem createSystem)
            // {
            //     if (!_createS.TryGetValue(type, out var createSystems))
            //     {
            //         createSystems = new List<IBuffCreateSystem>();
            //         _createS.Add(type, createSystems);
            //     }
            //
            //     _addSystem(createSystems, createSystem);
            // }
            
            _addSystem(_systems, buffSystem);
            
            // if (buffSystem is IBuffUpdateSystem updateSystem)
            // {
            //     if (!_updateS.TryGetValue(type, out var updateSystems))
            //     {
            //         updateSystems = new List<IBuffUpdateSystem>();
            //         _updateS.Add(type, updateSystems);
            //     }
            //
            //     _addSystem(updateSystems,updateSystem);
            // }
            //
            // if (buffSystem is IBuffDestroySystem destroySystem)
            // {
            //     if (!_destoryS.TryGetValue(type, out var destroySystems))
            //     {
            //         destroySystems = new List<IBuffDestroySystem>();
            //         _destoryS.Add(type, destroySystems);
            //     }
            //
            //     _addSystem(destroySystems, destroySystem);
            // }

            void _addSystem<TS>(IList<TS> systems,TS system)
            {
                if (!systems.Contains(system))
                {
                    systems.Add(system);
                }
#if UNITY_EDITOR
                else
                {
                    Debug.LogError($"Repeat registration {system}");
                }
#endif
            }
        }
    }
}