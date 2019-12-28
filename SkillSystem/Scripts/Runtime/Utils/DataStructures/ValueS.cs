using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    [Serializable]
    public class ValueS
    {
        //Boxing ValueInfo 
        private ValueInfo<object> _boxValueInfo = new ValueInfo<object>();
        
        [SerializeField] private bool _isUnity;

        public bool IsUnity => _isUnity;

        [SerializeField] private string ValueTypeAqName;
        
        [SerializeField] private string ValueInfoTypeAqName;

        [SerializeField] private string _valueStr;

        private AValueInfo _value;

        public AValueInfo ValueInfo
        {
            get
            {
                if (_value == null)
                {
                    GetValue<object>();
                }

                return _value;
            }
        }

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

                if (_type != null)
                {
                    var type = typeof(ValueInfo<>);

                    _valueInfoType = type.MakeGenericType(ValueType);
                    
                    ValueInfoTypeAqName = _valueInfoType.AssemblyQualifiedName;
                }
                else
                {
                    _valueInfoType = null;
                    ValueInfoTypeAqName = string.Empty;
                }
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
            SetValue(value,typeof(T));
        }

        public T GetValue<T>()
        {
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
                        SetValue(Activator.CreateInstance(ValueType),ValueType);
                    }
                }
            }

            if (typeof(T) == typeof(object) && ValueType.IsValueType)
            {
                //runtime appear boxing action,error 
                if (Application.isPlaying)
                {
                    Debug.LogWarning("Boxing !!!!! You should not do this, unless this is required, please troubleshoot the corresponding code");
                }

                _boxValueInfo.Value = _value.GetValue();

                return (T) _boxValueInfo.Value;
            }
            
            return ((ValueInfo<T>) _value).Value;
        }
        
        public void SetValue(object value,Type type)
        {
            if (value == null)
            {
                ValueType = null;
                _value = null;
                _valueStr = string.Empty;
                return;
            }
            
            ValueType = type;

            if (_value == null)
            {
                _value = (AValueInfo) Activator.CreateInstance(_valueInfoType);
            }
            
            _value.GetType().GetField(nameof(ValueInfo<object>.Value)).SetValue(_value,value);
            
            _valueStr = SerializationUtil.ToString(_value,_valueInfoType);
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