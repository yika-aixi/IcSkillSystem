using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    [Serializable]
    public class ValueS
    {
        [SerializeField] private bool _isUnity;

        public bool IsUnity => _isUnity;

        [SerializeField] private string ValueTypeAqName;
        
        [SerializeField] private string ValueInfoTypeAqName;

        [SerializeField] private string _valueStr;

        private AValueInfo _value;

        [SerializeField] private Object _uValue;
        public Object UValue => _uValue;

        private Type _type;
        
        private Type _valueInfoType;

        public Type ValueType
        {
            get
            {
                if (_type == null && !string.IsNullOrWhiteSpace(ValueTypeAqName))
                {
                    _type = Type.GetType(ValueTypeAqName);
                    _valueInfoType = Type.GetType(ValueInfoTypeAqName);
                }

                return _type;
            }

            set
            {
                _isUnity = typeof(Object).IsAssignableFrom(value);

                _type = value;

                ValueTypeAqName = value != null ? value.AssemblyQualifiedName : string.Empty;
                
                var type = typeof(ValueInfo<>);

                _valueInfoType = type.MakeGenericType(ValueType);
                ValueInfoTypeAqName = _valueInfoType.AssemblyQualifiedName;
            }
        }

        public ValueS(ValueS valueS)
        {
            ValueType = valueS.ValueType;
        }

        public ValueS()
        {
        }

        public void SetValue<T>(T value)
        {
            ValueType = typeof(T);

            if (_isUnity)
            {
                _uValue = value as Object;
                
                return;
            }

            if (value == null)
            {
                _value = null;
                _valueStr = string.Empty;
                return;
            }
            
            if (_value == null)
            {
                _value = (AValueInfo) Activator.CreateInstance(_valueInfoType);
            }
            
            _value.GetType().GetField(nameof(ValueInfo<object>.Value)).SetValue(_value,value);
            
            //todo bug Valueinfo no Serialization ,Serialization is AValueInfo
            //todo The reason is because utf8Json does not have non-generic serialization, I need to replace serialization library
            _valueStr = SerializationUtil.ToString(_value);
        }

        public T GetValue<T>()
        {
            if (_isUnity)
            {
                return (T) (object) UValue;
            }

            if (ValueType == null)
            {
                Debug.LogWarning("No Select Type!");
                return default;
            }

            if (_value == null)
            {
                _value = (AValueInfo) SerializationUtil.ToValue(_valueStr, _valueInfoType);

                if (_value == null)
                {
                    if (ValueType == typeof(string))
                    {
                        SetValue(string.Empty);
                    }
                    else
                    {
                        SetValue((T) Activator.CreateInstance(ValueType));
                    }
                }
            }

            return ((ValueInfo<T>) _value).Value;
        }
    }
    
    [Serializable]
    public class ValueSDict:SerializationDict<string,ValueS>
    {
        public static implicit operator Dictionary<string, object>(ValueSDict map)
        {
            var dict = new Dictionary<string, object>();

            foreach (var pair in map)
            {
                dict.Add(pair.Key,pair.Value.GetValue<object>());
            }

            return dict;
        }
    }
}