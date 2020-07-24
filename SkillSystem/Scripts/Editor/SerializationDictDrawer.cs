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
        private SerializedProperty _keysSer;
        private SerializedProperty _valuesSer;
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            Position = position;
            _height = 20;

            var rect = Position;
            rect.size = new Vector2(rect.size.x, 20);

            _foldoutState = EditorGUI.Foldout(rect, _foldoutState, GetTitle(label), true);
            
            if (!_foldoutState)
            {
                return;
            }
            rect.position += new Vector2(0, _height);
            
            var topHeight = DrawTop(rect) + 5;
            rect.position += new Vector2(0, topHeight);
            _height += topHeight;

            var map = GetMap();

            var keys = map.Keys.ToList();
            
            foreach (var key in keys)
            {
                var value = map[key];

                var height = DrawItem(rect, map, new KeyValuePair<TKey, TValue>(key, value)) + 10;
                rect.position += new Vector2(0, height);
                _height       += height;
            }
            
        }

        protected virtual float DrawTop(Rect position)
        {
            var rect = position;
            rect.size = new Vector2(position.size.x,20);
            if (GUI.Button(rect,GetButtonContent()))
            {
                AddKey();
            }

            return 20;
        }

        protected virtual void AddKey()
        {
            _keysSer.InsertArrayElementAtIndex(_keysSer.arraySize);
            ResetKeyValue(_keysSer.GetArrayElementAtIndex(_keysSer.arraySize - 1));
            Save();
        }

        protected abstract void ResetKeyValue(SerializedProperty key);

        protected virtual GUIContent GetButtonContent()
        {
            return new GUIContent("Add Item");
        }

        protected virtual GUIContent GetTitle(GUIContent label)
        {
            return label;
        }

        /// <summary>
        /// 需要重写<see cref="GetKeyValue"/>才可正常使用
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SerializedProperty GetItemValueProperty(TKey key)
        {
            for (var i = 0; i < _keysSer.arraySize; i++)
            {
                TKey keyValue = GetKeyValue(_keysSer.GetArrayElementAtIndex(i));
                
                if (Equals(keyValue, key))
                {
                    return _valuesSer.GetArrayElementAtIndex(i);
                }
            }

            return null;
        }

        protected virtual TKey GetKeyValue(SerializedProperty keySer)
        {
            return default;
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            Property   = property;
            _keysSer   = Property.FindPropertyRelative(SerializationDict<object, object>.KeysFieldName);
            _valuesSer = Property.FindPropertyRelative(SerializationDict<object, object>.ValuesFieldName);

            return _height;
        }

        protected abstract float DrawItem(Rect rect, SerializationDict<TKey, TValue> map,
            KeyValuePair<TKey, TValue> item);

        protected virtual void DrawRemoveButton(Rect rect,SerializationDict<TKey, TValue> map,KeyValuePair<TKey, TValue> item)
        {
            if (GUI.Button(rect,new GUIContent(
#if UNITY_2020_2
                (Texture) EditorGUIUtility.Load("d_p4_deletedlocal")
#else
                EditorGUIUtility.FindTexture(
#if UNITY_2020_1
                "collabdeleted icon"
#else
                "d_P4_DeletedLocal"
#endif
                )
#endif
                ,"Remove Item")))
            {
                map.Remove(item.Key);
                Save();
            }
        }
        
        protected void Save()
        {
            Property.serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(Property.serializedObject.targetObject);
            Property.serializedObject.Update();
        }
    }
}