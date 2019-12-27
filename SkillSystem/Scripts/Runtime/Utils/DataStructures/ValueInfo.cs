using System;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    [Serializable]
    public abstract class AValueInfo
    {
        public abstract object GetValue();
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
        
        public override object GetValue() => Value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}