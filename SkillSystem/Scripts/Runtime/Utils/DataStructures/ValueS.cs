using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    [Serializable]
    public class ValueS
    {
        //Boxing ValueInfo 
        private ValueInfo<object> _boxValueInfo = new ValueInfo<object>();

        [SerializeField] private string ValueTypeAqName;
        
        [SerializeField] private string ValueInfoTypeAqName;

        [SerializeField] private string _valueStr;

        [SerializeField] private Object _uValue;

        public bool IsUValue => ValueType.IsAssignableFrom(typeof(Object));
        
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

        public void SetValueInfo(AValueInfo valueInfo)
        {
            if (valueInfo == null)
            {
                ValueType = null;
                _value = null;
                _valueStr = string.Empty;
                return;
            }

            var type = valueInfo.ValueType;
            
            if (ValueType != type)
            {
                ValueType = type;
            }

            _value = valueInfo;
        }
        
        public void SetValue<T>(T value)
        {
            if (value == null)
            {
                ValueType = null;
                _value = null;
                _valueStr = string.Empty;
                return;
            }

            var type = typeof(T);
            
            if (ValueType != type)
            {
                ValueType = type;
            }

            if (_value == null)
            {
                _value = (AValueInfo) Activator.CreateInstance(_valueInfoType);
            }

            var valueInfo = (ValueInfo<T>) _value;

            valueInfo.Value = value;
        }

        public AValueInfo GetValueInfo()
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
                        try
                        {
                            SetValue(Activator.CreateInstance(ValueType),ValueType);
                        }
                        catch (InvalidCastException)
                        {
                        }
                    }
                }
            }

            return _value;
        }

        public ValueInfo<T> GetValue<T>()
        {
            if (IsUValue)
            {
                Debug.LogError($"Value Is Unity Type. pls -> '{nameof(GetUnityValue)}'");
                return null;
            }
            
            GetValueInfo();
            
            if (typeof(T) == typeof(object) && ValueType.IsValueType)
            {
                //runtime appear boxing action,error 
                if (Application.isPlaying)
                {
                    Debug.LogWarning("Boxing !!!!! You should not do this, unless this is required, please troubleshoot the corresponding code");
                }

                _boxValueInfo.Value = _value.GetValue();

                return (ValueInfo<T>) _boxValueInfo;
            }

            return (ValueInfo<T>) _value;
        }

        public Object GetUnityValue()
        {
            return GetUnityValue<Object>();
        }
        
        public T GetUnityValue<T>() where T : Object
        {
            return (T) _uValue;
        }
        
        public void SetUnityValue(Object value)
        {
            _uValue = value;
        }
        
        public void SetValue<T>(T value,Type type)
        {
            if (value == null)
            {
                ValueType = null;
                _value = null;
                _valueStr = string.Empty;
                return;
            }

            if (ValueType != type)
            {
                ValueType = type;
            }

            if (_value == null)
            {
                _value = (AValueInfo) Activator.CreateInstance(_valueInfoType);
            }
            
            var valueInfo = (ValueInfo<T>) _value;
            valueInfo.Value = value;
        }

        public void Save()
        {
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