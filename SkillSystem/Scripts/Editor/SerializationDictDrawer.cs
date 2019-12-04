using System.Collections.Generic;
using System.Linq;
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

        protected Rect Position;
        float _height;
        private bool _foldoutState;
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            Position = position;
            _height = 20;
            var rect = position;
            rect.size = new Vector2(position.size.x,20);
            if (GUI.Button(rect,GetButtonContent()))
            {
                var keysSer = property.FindPropertyRelative(SerializationDict<TKey, TValue>.KeysFieldName);
                
                keysSer.InsertArrayElementAtIndex(keysSer.arraySize);
                
                keysSer.GetArrayElementAtIndex(keysSer.arraySize - 1).stringValue = keysSer.arraySize.ToString();
            }
            
            rect.size = new Vector2(position.size.x,20);
            rect.position += new Vector2(0,_height);
            _height += 20;

            _foldoutState = EditorGUI.Foldout(rect, _foldoutState,GetTitle(),true);

            if (!_foldoutState)
            {
                return;
            }
            
            var map = GetMap(property);

            int index = 0;

            var keys = map.Keys.ToList();
            _height += 20;
            rect.position += new Vector2(0,20);
            foreach (var key in keys)
            {
                var value = map[key];
                
                rect.position += new Vector2(0,index * ItemHeight() + 10);

                EditorGUI.indentLevel++;
                {
                    _height += DrawItem(rect, map, new KeyValuePair<TKey, TValue>(key,value));
                }
                EditorGUI.indentLevel--;
                
                index++;
            }

            property.serializedObject.ApplyModifiedProperties();
        }

        protected virtual GUIContent GetButtonContent()
        {
            return new GUIContent("Add Item");
        }

        protected virtual GUIContent GetTitle()
        {
            return new GUIContent("Dict");
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return _height;
        }

        protected abstract float DrawItem(Rect rect, SerializationDict<TKey, TValue> map,
            KeyValuePair<TKey, TValue> item);

        protected void Save(SerializationDict<TKey, TValue> map)
        {
            
        }


        protected virtual float ItemHeight()
        {
            return 20f;
        }
    }
}