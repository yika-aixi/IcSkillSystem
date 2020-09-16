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
        private ValueInfo<object> _boxValueInfo;

        [SerializeField] private string ValueTypeAqName;
        
        [SerializeField] private string ValueInfoTypeAqName;

        [SerializeField] private string _valueStr;

        [SerializeField] private Object _uValue;
        public bool IsArray;

        public bool IsUValue => typeof(Object).IsAssignableFrom(ValueType);
        
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
                if (IsArray && value != null)
                {
                    var array = Array.CreateInstance(value, 0);
                    _type = array.GetType();
                }
                else
                {
                    _type = value;
                }

                ValueTypeAqName = _type != null ? _type.AssemblyQualifiedName : string.Empty;

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
            
            var type = value.GetType();
            
            if (ValueType != type)
            {
                ValueType = type;
            }

            if (IsUValue)
            {
                SetUnityValue((Object)(object)value);
                return;
            }

            if (_value == null)
            {
                _value = (AValueInfo) Activator.CreateInstance(_valueInfoType);
            }

            var valueInfo = _value as ValueInfo<T>;

            if (valueInfo != null)
            {
                valueInfo.Value = value;
            }
            else
            {
#if UNITY_EDITOR
                //runtime appear boxing action,error 
                if (Application.isPlaying && type.IsValueType)
                {
                    Debug.LogWarning("Boxing !!!!! You should not do this, unless this is required, please troubleshoot the corresponding code");
                }
#endif
                _value.SetValue(value);
            }

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
                if (string.IsNullOrWhiteSpace(_valueStr))
                {
                    var vT = typeof(ValueInfo<>).MakeGenericType(ValueType);
                    _value = (AValueInfo) Activator.CreateInstance(vT);
                }
                else
                {
                   _value = (AValueInfo) SerializationUtil.ToValue(_valueStr, _valueInfoType);
                }
            }

            if (_value == null || _value.GetValue() == null)
            {
                if (ValueType == typeof(string))
                {
                    SetValue(string.Empty);
                }
                else
                {
                    try
                    {
                        if (!IsArray)
                        {
              
                            SetValue(Activator.CreateInstance(ValueType),ValueType);
                        }
                        else
                        {
                            var eType = ValueType.GetElementType();
                            var array = Array.CreateInstance(eType, 0);
                            SetValue(array);
                        }
                    }
                    catch (InvalidCastException e)
                    {
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
#if UNITY_EDITOR
                //runtime appear boxing action,error 
                if (Application.isPlaying)
                {
                    Debug.LogWarning("Boxing !!!!! You should not do this, unless this is required, please troubleshoot the corresponding code");
                }
#endif
                _boxValueInfo = _value.GetValue();

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
            
            var valueInfo = _value as ValueInfo<T>;

            if (valueInfo != null)
            {
                valueInfo.Value = value;
            }
            else
            {
#if UNITY_EDITOR
                //runtime appear boxing action,error 
                if (Application.isPlaying && type.IsValueType)
                {
                    Debug.LogWarning("Boxing !!!!! You should not do this, unless this is required, please troubleshoot the corresponding code");
                }
#endif
                _value.SetValue(value);
            }
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