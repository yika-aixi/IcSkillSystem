using System;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    [Serializable]
    public abstract class AValueInfo
    {
        public object GetValue()
        {
            return ObjValue;
        }

        protected abstract object ObjValue { get; }
    }
    
    [Serializable]
    public class ValueInfo<T>:AValueInfo
    {
        public T Value;
        
        public static implicit operator T(ValueInfo<T> valueInfo)
        {
            return valueInfo.Value;
        }

        public static implicit operator ValueInfo<T>(T value)
        {
            return new ValueInfo<T>(){Value = value};
        }
        
        protected override object ObjValue => Value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}