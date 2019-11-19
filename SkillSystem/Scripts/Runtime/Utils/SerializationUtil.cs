//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月16日-01:00
//CabinIcarus.IcSkillSystem.Runtime

using System;
using Utf8Json;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    public static class SerializationUtil
    {
        public static string ToString<T>(T value)
        {
            return JsonSerializer.ToJsonString(value);
        }

        public static T ToValue<T>(string str)
        {
            if (string.IsNullOrEmpty(str) || str == "null")
            {
                return default;
            }
            
            return JsonSerializer.Deserialize<T>(str);
        }
        
        public static object ToValue(string str,Type type)
        {
            if (string.IsNullOrEmpty(str) || str == "null")
            {
                return null;
            }
            
            var value = JsonSerializer.NonGeneric.Deserialize(type,str);
            return value;
        }
    }
}