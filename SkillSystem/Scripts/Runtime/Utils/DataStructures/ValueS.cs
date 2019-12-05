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

        [SerializeField] private string _valueStr;

        private object _value;

        [SerializeField] private Object _uValue;
        public Object UValue => _uValue;

        private Type _type;

        public Type ValueType
        {
            get
            {
                if (_type == null && !string.IsNullOrWhiteSpace(ValueTypeAqName))
                {
                    _type = Type.GetType(ValueTypeAqName);
                }

                return _type;
            }

            set
            {
                _isUnity = typeof(Object).IsAssignableFrom(value);

                _type = value;

                ValueTypeAqName = value != null ? value.AssemblyQualifiedName : string.Empty;
            }
        }

        public ValueS(ValueS valueS)
        {
            ValueType = valueS.ValueType;
        }

        public ValueS()
        {
        }

        public void SetValue(object value)
        {
            ValueType = value?.GetType();

            if (_isUnity)
            {
                _uValue = (Object) value;
                return;
            }

            _valueStr = SerializationUtil.ToString(value);
        }

        public object GetValue()
        {
            if (_isUnity)
            {
                return UValue;
            }

            if (ValueType == null)
            {
                Debug.LogWarning("No Select Type!");
                return null;
            }

            return SerializationUtil.ToValue(_valueStr, ValueType);
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
                dict.Add(pair.Key,pair.Value.GetValue());
            }

            return dict;
        }

        public static explicit operator ValueSDict(Dictionary<string, object> dict)
        {
            var map = new ValueSDict();
            
            foreach (var valuePair in dict)
            {
                var valueS = new ValueS();
                valueS.SetValue(valuePair.Value);
                map.Add(valuePair.Key,valueS);
            }

            return map;
        }
    }
}