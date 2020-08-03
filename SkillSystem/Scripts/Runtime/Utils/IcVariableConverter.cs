//Create: Icarus
//ヾ(•ω•`)o
//2020-08-03 05:20
//CabinIcarus.IcSkillSystem.Runtime

using System;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.SkillSystem.Scripts.Runtime.Utils
{
    public class IcVariableConverter:JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var token = JToken.FromObject(((AValueInfo) value).GetValue(), serializer);
            
            token.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = (AValueInfo) Activator.CreateInstance(objectType);

            var jObj = JObject.Load(reader);
            
            obj.SetValue(jObj.ToObject(obj.ValueType));

            return obj;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(AValueInfo).IsAssignableFrom(objectType);
        }

        public override bool CanRead { get; } = true;
    }
}