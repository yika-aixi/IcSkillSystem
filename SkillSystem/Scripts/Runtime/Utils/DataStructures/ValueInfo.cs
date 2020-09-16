using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

[assembly: InternalsVisibleTo("CabinIcarus.IcSkillSystem.xNodeIc.Editor")]
namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    public abstract class AValueInfo
    {
        public object GetValue()
        {
            return ObjValue;
        }

        internal abstract void SetValue(object value);

        public void SetValue(AValueInfo value)
        {
            UpdateValue(value);
        }

        protected abstract void UpdateValue(AValueInfo value);
        
        protected abstract object ObjValue { get; }

        public abstract Type ValueType { get; }
        
        static Dictionary<Type,ConcurrentQueue<AValueInfo>> _buffer = new Dictionary<Type, ConcurrentQueue<AValueInfo>>();

        public static void FreeAllBuffer()
        {
            _buffer.Clear();
        }
        
        public static void FreeBuffer(Type type)
        {
            _buffer.Remove(type);
        }

        internal static AValueInfo GetValueInfo(Type type)
        {
            if (_buffer.TryGetValue(type, out var valueInfos))
            {
                if (valueInfos.TryDequeue(out var valueInfo))
                {
                    return valueInfo;
                }
            }

            return null;
        }

        internal static void AddBuffer(Type type, AValueInfo value)
        {
            if (!_buffer.TryGetValue(type, out var valueInfos))
            {
                valueInfos = new ConcurrentQueue<AValueInfo>();
                
                _buffer.Add(type,valueInfos);
            }
            
            valueInfos.Enqueue(value);
        } 
    }
    
    [Serializable]
    public class ValueInfo<T>:AValueInfo,IDisposable
    {
        public T Value;

        private ValueInfo()
        {
        }

        public static implicit operator T(ValueInfo<T> valueInfo)
        {
            return valueInfo.Value;
        }

        public static implicit operator ValueInfo<T>(T value)
        {
            var valueInfo = GetValueInfo(typeof(T));

            if (valueInfo == null)
            {
                valueInfo = new ValueInfo<T>();
            }

            var valueT = (ValueInfo<T>) valueInfo;

            valueT.Value = value;

            return valueT;
        }

        private bool _isRelease;
        
        public void Release()
        {
            if (_isRelease)
            {
                return;
            }
            
            _isRelease = true;
            AddBuffer(typeof(T), this);
        }

        public void FreeBuffer()
        {
            FreeBuffer(typeof(T));
        }
        
        internal override void SetValue(object value)
        {
            Value = (T) value;
        }

        protected override void UpdateValue(AValueInfo value)
        {
            if (value is ValueInfo<T> valueInfo)
            {
                Value = valueInfo.Value;
            }
        }

        protected override object ObjValue => Value;
        
        public override Type ValueType => Value?.GetType();

        public override string ToString()
        {
            return Value.ToString();
        }

        public void Dispose()
        {
            Release();
        }
    }
}