//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月28日-19:28
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using System;
using System.Collections.Generic;

namespace IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Utils
{
    public class ReferenceObjectPool
    {
        class ObjectState
        {
            public WeakReference Reference;
            public bool UseState;

            public ObjectState(object obj):this(obj,true)
            {
            }

            public ObjectState(object obj, bool use)
            {
                this.Reference = new WeakReference(obj,false);
                UseState = use;
            }
        }

        private Dictionary<Type, List<ObjectState>> _objectCache;

        /// <summary>
        /// 开启:归还对象时如果不是<see cref="ReferenceObjectPool"/>创建得对象就加入缓存
        /// 关闭:不会做任何处理
        /// </summary>
        public bool RecedeCache;

        public ReferenceObjectPool()
        {
            _objectCache = new Dictionary<Type, List<ObjectState>>();
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="args"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetObject<T>(params object[] args)
        {
            var type = typeof(T);
            
            return (T) GetObject(type,args);
        }
        
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="args"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public object GetObject(Type type,params object[] args)
        {
            object obj = null;
            
            if (!_objectCache.TryGetValue(type,out var result))
            {
                result = new List<ObjectState>();
                _objectCache.Add(type,result);
            }

            foreach (var state in result)
            {
                if (!state.UseState && state.Reference.IsAlive)
                {
                    obj = state.Reference.Target;
                }
            }

            if (obj == null)
            {
                obj = Activator.CreateInstance(type,args);
                
                result.Add(new ObjectState(obj));
            }

            return obj;
        }

        /// <summary>
        /// 归还对象
        /// <see cref="RecedeCache"/> 为true时对象不是从pool拿出的会被加入pool
        /// </summary>
        /// <param name="obj"></param>
        public void Recede(object obj)
        {
            var type = obj.GetType();
            
            if (!_objectCache.TryGetValue(type,out var result))
            {
                if (RecedeCache)
                {
                    result = new List<ObjectState>();
                    _objectCache.Add(type,result);
                }
                return;
            }

            bool hit = false;
            
            foreach (var objectState in result)
            {
                if (objectState.Reference.Target == obj)
                {
                    hit = true;
                    objectState.UseState = false;
                }
            }

            if (!hit && RecedeCache)
            {
                result.Add(new ObjectState(obj,false));
            }
        }

        public void CleanUp()
        {
            foreach (var objectCacheValue in _objectCache)
            {
                for (var index = objectCacheValue.Value.Count - 1; index >= 0; index--)
                {
                    var state = objectCacheValue.Value[index];
                    if (!state.Reference.IsAlive)
                    {
                        objectCacheValue.Value.RemoveAt(index);
                    }
                }

                if (objectCacheValue.Value.Count == 0)
                {
                    _objectCache.Remove(objectCacheValue.Key);
                }
            }
        }
    }
}