using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.Editor
{
    [CustomPropertyDrawer(typeof(ValueSDict))]
    public class ValueSDictPropertyDrawer : SerializationDictDrawer<string,ValueS>
    {
        private static ValueEditPopupWindow _valueEditPopup;
        private static SimpleTypeSelectPopupWindow _simpleTypeSelectPopup;
        protected override float DrawItem(Rect rect, SerializationDict<string, ValueS> map,
            KeyValuePair<string, ValueS> item)
        {
            if (_valueEditPopup == null || _simpleTypeSelectPopup == null)
            {
                _valueEditPopup = new ValueEditPopupWindow();
                _simpleTypeSelectPopup = new SimpleTypeSelectPopupWindow(true);
            }

            var keyRect = rect;
            
            keyRect.size = new Vector2(Position.width / 4,20);
            
            var valueRect = keyRect;
            
            valueRect.position += new Vector2(keyRect.size.x + 10,0);
            valueRect.size = rect.size - keyRect.size;
            valueRect.size += new Vector2(0,keyRect.height);
            {
                string newKey;
                
                var key = item.Key;
                var value = item.Value;

                if (value == null)
                {
                    value = new ValueS();
                    map[key] = value;
                }
                
                EditorGUI.BeginChangeCheck();
                {
                    newKey = EditorGUI.DelayedTextField(keyRect,key);
                }
                if (EditorGUI.EndChangeCheck())
                {
                    if (!string.IsNullOrEmpty(newKey))
                    {
                        map.Remove(key);
                        map.Add(newKey, item.Value);
                        Save();
                    }
                }

                if (value.ValueType == null)
                {
                    _drawValueTypeSelect(ref valueRect,value);
                }
                else
                {
                    _drawValue(ref valueRect,value);
                }
                var buttonRect = valueRect;
                buttonRect.size = new Vector2(26,26);
                if (value.ValueType != null)
                {
                    if (GUI.Button(buttonRect,new GUIContent(EditorGUIUtility.FindTexture("Refresh"),$"Change Type,Current Type '{value.ValueType.FullName}'")))
                    {
                        value.SetValue<object>(null);
                        value.Save();
                        Save();
                        return 0;
                    }
                    
                    buttonRect.position += new Vector2(30,0);
                }
                buttonRect.position = new Vector2(rect.width - 10, buttonRect.position.y);
                DrawRemoveButton(buttonRect,map, item);
            }
            
            return 30;
        }
        
        protected override void ResetKeyValue(SerializedProperty key)
        {
            key.stringValue = GetMap().Count.ToString();
        }

        private void _drawValueTypeSelect(ref Rect rect,ValueS value)
        {
            rect.size = new Vector2(100,26);
            value.IsArray = GUI.Toggle(rect,value.IsArray, "Array?");
            rect.position += new Vector2(105,0);
            
            rect.size = new Vector2(26,26);
            
            if (GUI.Button(rect,new GUIContent("Ｔ","Select Type")))
            {
                _simpleTypeSelectPopup.OnChangeTypeSelect = type =>
                {
                    value.ValueType = type;
                    Save();
                    _simpleTypeSelectPopup.editorWindow.Close();
                };
                
                var size = 250;
                var position = rect;
                position.position += new Vector2(0,20 + 5);
                
                position.size = new Vector2(size,size);
                
                PopupWindow.Show(rect,
                    _simpleTypeSelectPopup);
            }
            
            rect.position += new Vector2(30,0);
        }

        private void _drawValue(ref Rect rect,ValueS valueS)
        {
            var primitiveOrStringOrUnityType = _primitiveOrStringType(valueS) || valueS.IsUValue;
            
            rect.size = new Vector2(rect.width - (
                                        (primitiveOrStringOrUnityType ? 0: 70) //primitive Or String Or Unity Type No need to show edit button
                                        + 30 + 30) // subtract EditValue and Refresh and Remove Button 
                ,rect.height);
      
            _drawNoArrayValue(ref rect, valueS);

            if (!primitiveOrStringOrUnityType)
            {
                rect.size = new Vector2(70,26);
                
                if (GUI.Button(rect,"Edit Value"))
                {
                    _valueEditPopup.ValueS = valueS;

                    var pos = rect;
                    PopupWindow.Show(pos,_valueEditPopup);
                }
            }
            
            rect.position += new Vector2(rect.size.x + 10,0);
        }

        private void _drawNoArrayValue(ref Rect rect, ValueS valueS)
        {
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.ObjectField(pos, x.GetUnityValue(), x.ValueType, false));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.DelayedIntField(pos, x.GetValue<int>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.DelayedFloatField(pos, x.GetValue<float>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.DelayedDoubleField(pos, x.GetValue<double>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.LongField(pos, x.GetValue<long>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.DelayedTextField(pos, x.GetValue<string>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.Vector2Field(pos, "", x.GetValue<Vector2>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.Vector2IntField(pos, "", x.GetValue<Vector2Int>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.Vector3Field(pos, "", x.GetValue<Vector3>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.Vector3IntField(pos, "", x.GetValue<Vector3Int>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.Vector4Field(position: pos, "", x.GetValue<Vector4>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.ColorField(pos, x.GetValue<Color>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.CurveField(pos, x.GetValue<AnimationCurve>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.BoundsField(pos, x.GetValue<Bounds>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.BoundsIntField(pos, x.GetValue<BoundsInt>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.RectField(pos, x.GetValue<Rect>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.RectIntField(pos, x.GetValue<RectInt>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.EnumFlagsField(pos, x.GetValue<Enum>()));
            _drawValueField(ref rect, valueS, (pos, x) => EditorGUI.GradientField(pos, x.GetValue<Gradient>()));
        }

        private static bool _primitiveOrStringType(ValueS valueS)
        {
            return valueS.ValueType.IsPrimitive || valueS.ValueType == typeof(string);
        }

        void _drawValueField<T>(ref  Rect rect,ValueS valueS, Func<Rect,ValueS,T> drawAction)
        {
            if (!typeof(T).IsAssignableFrom(valueS.ValueType))
            {
                return;
            }
            
            var offset = new Vector2(15,0);
            rect.position -= offset; //subtract offset
            
            var value = drawAction(rect,valueS);
            
            if (GUI.changed)
            {
                if (valueS.IsUValue)
                {
                    valueS.SetUnityValue((Object) (object) value);
                }
                else
                {
                    valueS.SetValue(value);
                    valueS.Save();     
                }

                Save();
            }
        }
    }
}