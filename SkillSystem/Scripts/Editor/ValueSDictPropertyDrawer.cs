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
        private static ValueEditPopupWindow _ValueEditPopup;
        private static SimpleTypeSelectPopupWindow _simpleTypeSelectPopup;
        protected override float DrawItem(Rect rect, SerializationDict<string, ValueS> map,
            KeyValuePair<string, ValueS> item)
        {
            float height = 20;
            
            if (_ValueEditPopup == null || _simpleTypeSelectPopup == null)
            {
                _ValueEditPopup = new ValueEditPopupWindow();
                _simpleTypeSelectPopup = new SimpleTypeSelectPopupWindow(true);
            }

            var keyRect = rect;
            
            keyRect.size = new Vector2(Position.width / 4,height);
            
            var valueRect = keyRect;
            
            valueRect.position += new Vector2(keyRect.size.x + 10,0);
            valueRect.size = rect.size - keyRect.size;
            valueRect.size += new Vector2(0,rect.height);
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
//                        _save();
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
                        value.ValueType = null;
                        value.SetValue(null);
//                        _save();
                        return height;
                    }
                    
                    buttonRect.position += new Vector2(30,0);
                }

                if (GUI.Button(buttonRect,new GUIContent(EditorGUIUtility.FindTexture("d_P4_DeletedLocal"),"Remove Item")))
                {
                    map.Remove(key);
//                    _save();
                }
            }
            return height;
        }
        
        private void _drawValueTypeSelect(ref Rect rect,ValueS value)
        {
            rect.size = new Vector2(26,26);
            if (GUI.Button(rect,new GUIContent("Ｔ","Select Type")))
            {
                _simpleTypeSelectPopup.OnChangeTypeSelect = type =>
                {
                    value.ValueType = type;
//                    _save();
                    _simpleTypeSelectPopup.editorWindow.Close();
                };
                
                var size = 250;
                var position = rect;
                position.position += new Vector2(0,ItemHeight() + 5);
                
                position.size = new Vector2(size,size);
                
                PopupWindow.Show(rect,
                    _simpleTypeSelectPopup);
            }
            
            rect.position += new Vector2(30,0);
        }

        private void _drawValue(ref Rect rect,ValueS valueS)
        {
            var position = rect;
            //todo draw Value
            if (valueS.IsUnity)
            {
                position.size = new Vector2(rect.width - 80,position.height);
                rect.position += new Vector2(position.width,0);
                Object obj;
                EditorGUI.BeginChangeCheck();
                {
                    obj = EditorGUI.ObjectField(position,valueS.UValue, valueS.ValueType, false);
                }
                if (EditorGUI.EndChangeCheck())
                {
                    valueS.SetValue(obj);
//                    _save();
                }
            }
            else
            {
                //todo non Unity Type

                var value = valueS.GetValue();

                if (value == null)
                {
                    valueS.SetValue(Activator.CreateInstance(valueS.ValueType));
//                    _save();
                }

                _drawNonUnityValue<int>(ref rect,valueS, x => EditorGUI.DelayedIntField(position,(int) x.GetValue()));
                _drawNonUnityValue<float>(ref rect,valueS, x => EditorGUI.DelayedFloatField(position,(float) x.GetValue()));
                _drawNonUnityValue<double>(ref rect,valueS, x => EditorGUI.DelayedDoubleField(position,(double) x.GetValue()));
                _drawNonUnityValue<long>(ref rect,valueS, x => EditorGUI.LongField(position,(long) x.GetValue()));
                _drawNonUnityValue<string>(ref rect,valueS, x => EditorGUI.DelayedTextField(position,(string) x.GetValue()));
                _drawNonUnityValue<Vector2>(ref rect,valueS, x => EditorGUI.Vector2Field(position,"",(Vector2) x.GetValue()));
                _drawNonUnityValue<Vector2Int>(ref rect,valueS, x => EditorGUI.Vector2IntField(position,"",(Vector2Int) x.GetValue()));
                _drawNonUnityValue<Vector3>(ref rect,valueS, x => EditorGUI.Vector3Field(position,"",(Vector3) x.GetValue()));
                _drawNonUnityValue<Vector3Int>(ref rect,valueS, x => EditorGUI.Vector3IntField(position,"",(Vector3Int) x.GetValue()));
                _drawNonUnityValue<Vector4>(ref rect,valueS, x => EditorGUI.Vector4Field(position,"",(Vector4) x.GetValue()));
                _drawNonUnityValue<Color>(ref rect,valueS, x => EditorGUI.ColorField(position,(Color) x.GetValue()));
                _drawNonUnityValue<AnimationCurve>(ref rect,valueS, x => EditorGUI.CurveField(position,(AnimationCurve) x.GetValue()));
                _drawNonUnityValue<Bounds>(ref rect,valueS, x => EditorGUI.BoundsField(position,(Bounds) x.GetValue()));
                _drawNonUnityValue<BoundsInt>(ref rect,valueS, x => EditorGUI.BoundsIntField(position,(BoundsInt) x.GetValue()));
                _drawNonUnityValue<Rect>(ref rect,valueS, x => EditorGUI.RectField(position,(Rect) x.GetValue()));
                _drawNonUnityValue<RectInt>(ref rect,valueS, x => EditorGUI.RectIntField(position,(RectInt) x.GetValue()));
                _drawNonUnityValue<Enum>(ref rect,valueS, x => EditorGUI.EnumFlagsField(position,(Enum) x.GetValue()));
                _drawNonUnityValue<Gradient>(ref rect,valueS, x => EditorGUI.GradientField(position,(Gradient) x.GetValue()));

                rect.position += new Vector2(10,0);
                rect.size = new Vector2(100,26);
                if (GUI.Button(rect,"Edit Value"))
                {
                    var size = 250;

                    _ValueEditPopup.ValueS = valueS;

                    var pos = rect;
                    PopupWindow.Show(pos,_ValueEditPopup);
                }

                rect.position += new Vector2(rect.size.x,0);
            }
            rect.position += new Vector2(10,0);
        }

        void _drawNonUnityValue<T>(ref  Rect rect,ValueS valueS, Func<ValueS,object> drawAction)
        {
            if (!typeof(T).IsAssignableFrom(valueS.ValueType))
            {
                return;
            }
            
            rect.size = new Vector2(rect.width - 80,rect.height);
            rect.position += new Vector2(rect.width,0);
            
            var value = drawAction(valueS);
            
            if (GUI.changed)
            {
                valueS.SetValue(value);
                
//                _save();
            }
        }
    }
}