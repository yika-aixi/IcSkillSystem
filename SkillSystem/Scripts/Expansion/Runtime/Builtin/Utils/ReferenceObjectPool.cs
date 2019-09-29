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
            public Type ObjType { get; }
            public WeakReference Reference;
            public bool UseState;

            public ObjectState(object obj, bool use = true)
            {
                this.Reference = new WeakReference(obj,false);
                UseState = use;
                ObjType = obj.GetType();
            }
        }

        private List<ObjectState> _objectCache;

        /// <summary>
        /// 开启:归还对象时如果不是<see cref="ReferenceObjectPool"/>创建得对象就加入缓存
        /// 关闭:不会做任何处理
        /// </summary>
        public bool RecedeCache;

        public ReferenceObjectPool()
        {
            _objectCache = new List<ObjectState>();
        }

        public void AddObjectToPool(object obj,bool state)
        {
            _objectCache.Add(new ObjectState(obj,state));
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

            for (var i = 0; i < _objectCache.Count; i++)
            {
                var objectState = _objectCache[i];
                if (objectState.ObjType == type)
                {
                    if (!objectState.UseState && objectState.Reference.Target != null)
                    {
                        obj = objectState.Reference.Target;
                    }
                }
            }

            if (obj == null)
            {
                obj = Activator.CreateInstance(type,args);
                
                _objectCache.Add(new ObjectState(obj));
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
            bool hit = false;

            for (var i = 0; i < _objectCache.Count; i++)
            {
                var objectState = _objectCache[i];
                if (objectState.Reference.Target != null && objectState.UseState)
                {
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
            for (var index = _objectCache.Count - 1; index >= 0; index--)
            {
                var state = _objectCache[index];
                if (!state.Reference.IsAlive)
                {
                    _objectCache.RemoveAt(index);
                }
            }
        }


        public List<object> this[Type type,bool state]
        {
            get
            {
                List<object> _obj = new List<object>();

                for (var index = 0; index < _objectCache.Count; index++)
                {
                    var objectState = _objectCache[index];
                    if (objectState.ObjType == type && objectState.UseState == state)
                    {
                        _obj.Add(objectState.Reference.Target);
                    }
                }

                return _obj;
            }
        }
        
        public List<object> this[Type type]
        {
            get
            {
                List<object> _obj = new List<object>();

                _obj.AddRange(this[type, true]);
                _obj.AddRange(this[type, false]);

                return _obj;
            }
        }
    }
}