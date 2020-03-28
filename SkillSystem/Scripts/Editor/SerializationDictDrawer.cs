using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor
{
    public abstract class SerializationDictDrawer<TKey,TValue> : PropertyDrawer
    {
        private SerializationDict<TKey, TValue> _map;
        protected SerializationDict<TKey, TValue> GetMap()
        {
            if (_map == null)
            {
                _map = (SerializationDict<TKey, TValue>) this.fieldInfo.GetValue(Property.serializedObject.targetObject);
            }

            return _map;
        }

        protected Rect Position;
        float _height;
        private bool _foldoutState = true;
        protected SerializedProperty Property;
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            Property = property;
            Position = position;
            _height = 20;
            var rect = position;
            var topHeight = DrawTop(position);
            _height += topHeight;
            
            rect.size = new Vector2(position.size.x,20);
            rect.position += new Vector2(0,_height);
            _height += 20;

            _foldoutState = EditorGUI.Foldout(rect, _foldoutState,GetTitle(),true);

            if (!_foldoutState)
            {
                return;
            }
            
            var map = GetMap();

            int index = 0;

            var keys = map.Keys.ToList();
            
            rect.position += new Vector2(0,ItemHeight());
            foreach (var key in keys)
            {
                var value = map[key];
                EditorGUI.indentLevel++;
                {
                    _height += DrawItem(rect, map, new KeyValuePair<TKey, TValue>(key,value));
                }
                EditorGUI.indentLevel--;
                
                rect.position += new Vector2(0,ItemHeight() + 10);
                _height += ItemHeight() + 10;
                index++;
            }
            
            _height += 10;

            property.serializedObject.ApplyModifiedProperties();
        }

        protected virtual float DrawTop(Rect position)
        {
            var rect = position;
            rect.size = new Vector2(position.size.x,20);
            if (GUI.Button(rect,GetButtonContent()))
            {
                var keysSer = Property.FindPropertyRelative(SerializationDict<TKey, TValue>.KeysFieldName);
                AddKey(keysSer);
            }

            return 20;
        }

        protected virtual void AddKey(SerializedProperty keysSer)
        {
            keysSer.InsertArrayElementAtIndex(keysSer.arraySize);

            keysSer.GetArrayElementAtIndex(keysSer.arraySize - 1).stringValue = keysSer.arraySize.ToString();
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

        protected virtual void DrawRemoveButton(Rect rect,SerializationDict<TKey, TValue> map,KeyValuePair<TKey, TValue> item)
        {
            if (GUI.Button(rect,new GUIContent(EditorGUIUtility.FindTexture(
#if UNITY_2020_1
                "collabdeleted icon"
#else
                "d_P4_DeletedLocal"
#endif
                ),"Remove Item")))
            {
                map.Remove(item.Key);
                Save();
            }
        }
        
        protected void Save()
        {
            EditorUtility.SetDirty(Property.serializedObject.targetObject);
        }

        protected virtual float ItemHeight()
        {
            return 20f;
        }
    }
}