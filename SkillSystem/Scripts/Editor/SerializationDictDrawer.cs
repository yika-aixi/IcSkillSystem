using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor
{
    public abstract class SerializationDictDrawer<TKey,TValue> : PropertyDrawer
    {
        protected SerializationDict<TKey, TValue> GetMap(SerializedProperty property)
        {
            return (SerializationDict<TKey, TValue>) this.fieldInfo.GetValue(property.serializedObject.targetObject); 
        }  
        
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            if (GUI.Button(position,"Add Variable"))
            {
                var keysSer = property.FindPropertyRelative(SerializationDict<TKey, TValue>.KeysFieldName);
                
                keysSer.InsertArrayElementAtIndex(keysSer.arraySize);
            }

            var map = GetMap(property);

            foreach (var item in map)
            {
                DrawItem(map,item);
            }
        }

        protected abstract void DrawItem(SerializationDict<TKey, TValue> map, KeyValuePair<TKey, TValue> item);

        protected void Save(SerializationDict<TKey, TValue> map)
        {
            
        }
    }
}