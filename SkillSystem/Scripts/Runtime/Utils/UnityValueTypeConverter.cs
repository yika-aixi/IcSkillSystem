//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2020年02月26日-10:30
//Icarus.EditorFrame.Expansions

using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using UnityEngine;

namespace CabinIcarus.EditorFrame.Expansion.NewtonsoftJson
{
    public class UnityValueTypeConverter:JsonConverter
    {
        private readonly Type[] _types = new []
        {
            typeof(Vector2),
            typeof(Vector3),
            typeof(Vector2Int),
            typeof(Vector3Int),
            typeof(Vector4),
            typeof(Rect),
            typeof(Vector2),
            typeof(Color)
        };
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var fields = value.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            writer.WriteStartObject();
            {
                var length = fields.Length;
                
                for (var i = 0; i < length; i++)
                {
                    var fieldInfo = fields[i];
                    writer.WritePropertyName(fieldInfo.Name);
                    writer.WriteValue(fieldInfo.GetValue(value));
                }
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return _types.Any(t => t == objectType);
        }
    }
}