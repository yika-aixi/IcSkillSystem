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
        interface IObjectState
        {
            bool UseState { get; set; }

            object GetValue();
        }
        
        class WeakObjectState:IObjectState
        {
            public object Obj => _reference.Target;
            private WeakReference _reference;

            public WeakObjectState(object obj, bool use = true)
            {
                this._reference = new WeakReference(obj,false);
                UseState = use;
            }

            public bool UseState { get; set; }
            public object GetValue()
            {
                return _reference.Target;
            }
        }
        
        class ObjectState:IObjectState
        {
            public object Obj { get; }
            
            public int LastUseTime;
            
            public ObjectState(object obj, int lastUseTime, bool use = true)
            {
                Obj = obj;
                LastUseTime = lastUseTime;
                UseState = use;
            }

            public bool UseState { get; set; }
            public object GetValue()
            {
                return Obj;
            }
        }

        private long _starTime;
        
        /// <summary>
        /// 清理时间停留超过这个时间的对象
        /// </summary>
        public int ClearTime { get; }
        
        private Dictionary<Type, List<WeakObjectState>> _weakObjectCache;
        
        private Dictionary<Type, List<ObjectState>> _objectCache;
        
        private Dictionary<Type, Queue<IObjectState>> _objectCacheQueue;

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
            
            _objectCacheQueue = new Dictionary<Type, Queue<IObjectState>>();
            
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

            IObjectState _objectState;
            
            if (oResult.Count < MaxCount)
            {
                _objectState = new ObjectState(obj, _getCurrentSeconds(), state);
                oResult.Add((ObjectState) _objectState);
            }
            else
            {
                if (!_weakObjectCache.TryGetValue(type,out var result))
                {
                    result = new List<WeakObjectState>();
                
                    _weakObjectCache.Add(type,result);
                }

                _objectState = new WeakObjectState(obj, state);
                
                result.Add((WeakObjectState) _objectState);
            }
          
            if (!state)
            {
                if (!_objectCacheQueue.TryGetValue(type,out var queues))
                {
                    queues = new Queue<IObjectState>();
                    _objectCacheQueue.Add(type,queues);
                }

                queues.Enqueue(_objectState);
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
                    var state = result.Dequeue();
                    state.UseState = true;
                    obj = state.GetValue();
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
            bool hit = false;

            IObjectState qState = null;
            
            if (_objectCache.TryGetValue(type,out var oResult))
            {
                if (oResult.Count < MaxCount)
                {
                    foreach (var state in oResult)
                    {
                        if (state.Obj == obj)
                        {
                            qState = state;
                            hit = true;
                            state.UseState = false;
                            break;
                        }
                    }
                }
            }

            if (!hit)
            {
                if (_weakObjectCache.TryGetValue(type,out var result))
                {
                    foreach (var state in result)
                    {
                        if (state.Obj == obj)
                        {
                            qState = state;
                            hit = true;
                            state.UseState = false;
                            break;
                        }
                    }
                }
            }

            if (hit)
            {
                if (!_objectCacheQueue.TryGetValue(type, out var result))
                {
                    result = new Queue<IObjectState>();
                    _objectCacheQueue.Add(type, result);
                }
                
                result.Enqueue(qState);
            }
            
            if (!hit && RecedeCache)
            {
                AddObjectToPool(obj,false);
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
        public int GetTypeAllCacheCount(Type type)
        {
            int count = 0;
            
            if (_objectCache.TryGetValue(type, out var oResult))
            {
                count += oResult.Count;
            }
            
            if (_weakObjectCache.TryGetValue(type, out var wResult))
            {
                count += wResult.Count;
            }
            
            if (_objectCacheQueue.TryGetValue(type, out var qResult))
            {
                count += qResult.Count;
            }

            return count;
        }

        /// <summary>
        /// 获取类型队列缓存数量
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetCacheQueueCount(Type type)
        {
            int count = 0;

            if (_objectCacheQueue.TryGetValue(type, out var qResult))
            {
                count = qResult.Count;
            }

            return count;
        }
        
        /// <summary>
        /// 获取类型弱缓存数量
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetCacheWeakCount(Type type)
        {
            int count = 0;

            if (_weakObjectCache.TryGetValue(type, out var wResult))
            {
                count = wResult.Count;
            }

            return count;
        }
        
        /// <summary>
        /// 获取类型强缓存数量
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetCacheCount(Type type)
        {
            int count = 0;

            if (_objectCache.TryGetValue(type, out var oResult))
            {
                count = oResult.Count;
            }

            return count;
        }
    }
}