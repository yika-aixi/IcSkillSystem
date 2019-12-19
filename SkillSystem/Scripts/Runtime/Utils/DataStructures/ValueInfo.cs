using System;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    [Serializable]
    public class ValueInfo<T>
    {
        public T Value;
        
        public static implicit operator T(ValueInfo<T> valueInfo)
        {
            return valueInfo.Value;
        }
    }
}