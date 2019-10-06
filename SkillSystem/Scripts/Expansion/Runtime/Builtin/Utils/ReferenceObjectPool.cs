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
        class WeakObjectState
        {
            public object Obj => _reference.Target;
            private WeakReference _reference;
            public bool UseState;

            public WeakObjectState(object obj, bool use = true)
            {
                this._reference = new WeakReference(obj,false);
                UseState = use;
            }
        }
        
        class ObjectState
        {
            public object Obj { get; }
            
            public bool UseState;
            
            public int LastUseTime;
            
            public ObjectState(object obj, int lastUseTime, bool use = true)
            {
                Obj = obj;
                LastUseTime = lastUseTime;
                UseState = use;
            }
        }

        private long _starTime;
        
        /// <summary>
        /// 清理时间停留超过这个时间的对象
        /// </summary>
        public int ClearTime { get; }
        
        private Dictionary<Type, List<WeakObjectState>> _weakObjectCache;
        
        private Dictionary<Type, List<ObjectState>> _objectCache;
        
        private Dictionary<Type, Queue<object>> _objectCacheQueue;

        public int MaxCount;
        
        /// <summary>
        /// 开启:归还对象时如果不是<see cref="ReferenceObjectPool"/>创建得对象就加入缓存
        /// 关闭:不会做任何处理
        /// </summary>
        public bool RecedeCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cleatTime">Call<see cref="CleanUp"/>函数时,超过这个时间(秒)的对象会被释放</param>
        /// <param name="maxCount">最大缓存数,归还或添加时时会将超过这个数的缓存变为弱缓存</param>
        public ReferenceObjectPool(int cleatTime = 60, int maxCount = 30)
        {
            _weakObjectCache = new Dictionary<Type, List<WeakObjectState>>();
            
            _objectCache = new Dictionary<Type, List<ObjectState>>();
            
            _objectCacheQueue = new Dictionary<Type, Queue<object>>();
            
            MaxCount = maxCount;

            ClearTime = cleatTime;

            _starTime = _getCurrentSeconds();
        }

        int _getCurrentSeconds()
        {
            return (int) (DateTime.Now.Ticks / 10000000L % 60L);
        }

        /// <summary>
        /// 添加对象到池子
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="state"></param>
        public void AddObjectToPool(object obj,bool state)
        {
            var type = obj.GetType();

            var hit = _objectCache.TryGetValue(type, out var oResult);

            if (!hit)
            {
                oResult = new List<ObjectState>();

                _objectCache.Add(type,oResult);
            }
            
            if (oResult.Count < MaxCount)
            {
                oResult.Add(new ObjectState(obj,ClearTime,state));
            }
            else
            {
                if (!_weakObjectCache.TryGetValue(type,out var result))
                {
                    result = new List<WeakObjectState>();
                
                    _weakObjectCache.Add(type,result);
                }
                
                result.Add(new WeakObjectState(obj,state));
            }
          
            if (!state)
            {
                if (!_objectCacheQueue.TryGetValue(type,out var queues))
                {
                    queues = new Queue<object>();
                    _objectCacheQueue.Add(type,queues);
                }

                queues.Enqueue(obj);
            }
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

            if (_objectCacheQueue.TryGetValue(type, out var result))
            {
                if (result.Count > 0)
                {
                    obj = result.Dequeue();
                }
            }
            
            if (obj == null)
            {
                if (_weakObjectCache.TryGetValue(type, out var wResult))
                {
                    for (var i = wResult.Count - 1; i >= 0; i--)
                    {
                        var weakState = wResult[i];

                        if (!weakState.UseState)
                        {
                            if (weakState.Obj != null)
                            {
                                weakState.UseState = true;
                                obj = weakState.Obj;
                                break;
                            }

                            wResult.RemoveAt(i);
                        }
                    }
                }
            }
            
            if (obj == null)
            {
                if (_objectCache.TryGetValue(type, out var oResult))
                {
                    foreach (var objectState in oResult)
                    {
                        if (!objectState.UseState)
                        {
                            objectState.LastUseTime = _getCurrentSeconds();
                            objectState.UseState = true;
                            obj = objectState.Obj;
                        }
                    }
                }
            }
            
            if (obj == null)
            {
                obj = Activator.CreateInstance(type, args);
                AddObjectToPool(obj,true);
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

            if (!_objectCache.TryGetValue(type,out var oResult))
            {
                if (!RecedeCache)
                {
                    return;
                }
                
                AddObjectToPool(obj,false);

                return;
            }

            if (oResult.Count < MaxCount)
            {
                foreach (var objectState in oResult)
                {
                    if (objectState.Obj == obj)
                    {
                        objectState.UseState = false;
                        break;
                    }
                }
                
                return;
            }
            
            bool hit = false;
            
            if (_weakObjectCache.TryGetValue(type,out var result))
            {
                for (var i = 0; i < result.Count; i++)
                {
                    var objectState = result[i];
                    if (objectState.Obj == obj)
                    {
                        hit = true;
                        objectState.UseState = false;
                    }
                }

                //被回收了,加入弱引用缓存
                if (!hit)
                {
                    result.Add(new WeakObjectState(obj,false));
                }
            }
        }

        /// <summary>
        /// 清理被垃圾回收掉的缓存
        /// </summary>
        public void CleanUp()
        {
            foreach (var objectCacheValue in _weakObjectCache)
            {
                for (var index = objectCacheValue.Value.Count - 1; index >= 0; index--)
                {
                    var state = objectCacheValue.Value[index];
                    
                    if (state.Obj == null)
                    {
                        objectCacheValue.Value.RemoveAt(index);
                    }
                }
            }

            int curTime = _getCurrentSeconds();
            
            foreach (var objectCacheValue in _objectCache)
            {
                for (var index = objectCacheValue.Value.Count - 1; index >= 0; index--)
                {
                    var state = objectCacheValue.Value[index];
                    
                    if (curTime - _starTime > state.LastUseTime)
                    {
                        objectCacheValue.Value.RemoveAt(index);
                    }
                }
            }
        }

        
        /// <summary>
        /// 获取类型指定状态的列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="state"></param>
        public List<object> this[Type type,bool state]
        {
            get
            {
                List<object> _obj = new List<object>();

                if (!state)
                {
                    if(_objectCacheQueue.TryGetValue(type,out var qResult))
                    {
                        _obj.AddRange(qResult);
                    }
                }
                
                if(_weakObjectCache.TryGetValue(type,out var result))
                {
                    _obj.AddRange(result.Where(x=>x.UseState == state && x.Obj != null).Select(x=>x.Obj));
                }
                
                if(_objectCache.TryGetValue(type,out var oResult))
                {
                    _obj.AddRange(oResult.Where(x=>x.UseState == state && x.Obj != null).Select(x=>x.Obj));
                }

                return _obj;
            }
        }
        
        /// <summary>
        /// 获取类型的列表
        /// </summary>
        /// <param name="type"></param>
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

        /// <summary>
        /// 获取类型缓存的数量
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetTypeCacheCount(Type type)
        {
            return this[type].Count;
        }
    }
}