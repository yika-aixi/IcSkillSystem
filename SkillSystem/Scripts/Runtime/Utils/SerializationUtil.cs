//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月16日-01:00
//CabinIcarus.IcSkillSystem.Runtime

using System;
using CabinIcarus.OdinSerializer;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    public static class SerializationUtil
    {
        public static string ToString<T>(T value)
        {
            return ToString(value, null);
        }

        public static T ToValue<T>(string str)
        {
            return (T) ToValue(str, null);
        }
        
        public static string ToString(object value,Type type)
        {
            var bs = SerializationUtility.SerializeValueWeak(value,DataFormat.Binary);
            return Convert.ToBase64String(bs);
        }
        
        public static object ToValue(string str,Type type)
        {
            var bs = Convert.FromBase64String(str);
            return SerializationUtility.DeserializeValueWeak(bs,DataFormat.Binary);
        }
    }
}