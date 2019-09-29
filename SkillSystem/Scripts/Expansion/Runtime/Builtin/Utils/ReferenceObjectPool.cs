//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月28日-19:28
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using System;
using System.Collections.Generic;
using System.Linq;

namespace IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Utils
{
    public class ReferenceObjectPool
    {
        class ObjectState
        {
            public WeakReference Reference;
            public bool UseState;

            public ObjectState(object obj, bool use = true)
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

        public void AddObjectToPool(object obj,bool state)
        {
            var type = obj.GetType();
            
            if (!_objectCache.TryGetValue(type,out var result))
            {
                result = new List<ObjectState>();
                _objectCache.Add(type,result);
            }
            
            result.Add(new ObjectState(obj,state));
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

            for (var index = result.Count - 1; index >= 0; index--)
            {
                var state = result[index];
                if (!state.UseState)
                {
                    if (state.Reference.Target == null)
                    {
                        result.RemoveAt(index);
                    }
                    else
                    {
                        state.UseState = true;
                        obj = state.Reference.Target;
                    }
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
            bool hit = false;

            if (_objectCache.TryGetValue(type,out var result))
            {
                for (var i = 0; i < result.Count; i++)
                {
                    var objectState = result[i];
                    if (objectState.Reference.Target == obj)
                    {
                        hit = true;
                        objectState.UseState = false;
                    }
                }
            }

            if (!hit && RecedeCache)
            {
                AddObjectToPool(obj,false);
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


        public List<object> this[Type type,bool state]
        {
            get
            {
                List<object> _obj = new List<object>();
                
                if(_objectCache.TryGetValue(type,out var result))
                {
                    _obj.AddRange(result.Where(x=>x.UseState == state && x.Obj != null).Select(x=>x.Obj));
                }

                return _obj;
            }
        }
        
        public List<object> this[Type type]
        {
            get
            {
                List<object> _obj = new List<object>();
                
                _obj.AddRange(this[type,true]);
                _obj.AddRange(this[type,false]);

                return _obj;
            }
        }
    }
}