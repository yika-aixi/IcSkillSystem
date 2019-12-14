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
            
            keyRect.size = new Vector2(Position.width / 4,ItemHeight());
            
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
                        value.ValueType = null;
                        value.SetValue(null);
                        Save();
                        return 0;
                    }
                    
                    buttonRect.position += new Vector2(30,0);
                }
                buttonRect.position = new Vector2(rect.width - 10, buttonRect.position.y);
                if (GUI.Button(buttonRect,new GUIContent(EditorGUIUtility.FindTexture("d_P4_DeletedLocal"),"Remove Item")))
                {
                    map.Remove(key);
                    Save();
                }
            }
            return 0;
        }
        
        private void _drawValueTypeSelect(ref Rect rect,ValueS value)
        {
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
                position.position += new Vector2(0,ItemHeight() + 5);
                
                position.size = new Vector2(size,size);
                
                PopupWindow.Show(rect,
                    _simpleTypeSelectPopup);
            }
            
            rect.position += new Vector2(30,0);
        }

        private void _drawValue(ref Rect rect,ValueS valueS)
        {
            rect.size = new Vector2(rect.width - (70 + 30 + 10 + 30) // subtract EditValue and Refresh and Remove Button 
                ,rect.height);
           
            //todo draw Value
            if (valueS.IsUnity)
            {
                var offset = new Vector2(15,0);
                rect.position -= offset; //subtract offset
                
                rect.size += new Vector2(70,0);// no Edit Value Button
                Object obj;
                EditorGUI.BeginChangeCheck();
                {
                    obj = EditorGUI.ObjectField(rect,valueS.UValue, valueS.ValueType, false);
                }
                if (EditorGUI.EndChangeCheck())
                {
                    valueS.SetValue(obj);
                    Save();
                }
            }
            else
            {
                //todo non Unity Type

                var value = valueS.GetValue();

                if (value == null)
                {
                    if (valueS.ValueType == typeof(string))
                    {
                        valueS.SetValue(string.Empty);
                    }
                    else
                    {
                        valueS.SetValue(Activator.CreateInstance(valueS.ValueType));
                    }

                    Save();
                }

                _drawNonUnityValue<int>(ref rect,valueS, (pos,x) => EditorGUI.DelayedIntField(pos,(int) x.GetValue()));
                _drawNonUnityValue<float>(ref rect,valueS, (pos,x) => EditorGUI.DelayedFloatField(pos,(float) x.GetValue()));
                _drawNonUnityValue<double>(ref rect,valueS, (pos,x) => EditorGUI.DelayedDoubleField(pos,(double) x.GetValue()));
                _drawNonUnityValue<long>(ref rect,valueS, (pos,x) => EditorGUI.LongField(pos,(long) x.GetValue()));
                _drawNonUnityValue<string>(ref rect,valueS, (pos,x) => EditorGUI.DelayedTextField(pos,(string) x.GetValue()));
                _drawNonUnityValue<Vector2>(ref rect,valueS, (pos,x) => EditorGUI.Vector2Field(pos,"",(Vector2) x.GetValue()));
                _drawNonUnityValue<Vector2Int>(ref rect,valueS, (pos,x) => EditorGUI.Vector2IntField(pos,"",(Vector2Int) x.GetValue()));
                _drawNonUnityValue<Vector3>(ref rect,valueS, (pos,x) => EditorGUI.Vector3Field(pos,"",(Vector3) x.GetValue()));
                _drawNonUnityValue<Vector3Int>(ref rect,valueS, (pos,x) => EditorGUI.Vector3IntField(pos,"",(Vector3Int) x.GetValue()));
                _drawNonUnityValue<Vector4>(ref rect,valueS, (pos,x) => EditorGUI.Vector4Field(pos,"",(Vector4) x.GetValue()));
                _drawNonUnityValue<Color>(ref rect,valueS, (pos,x) => EditorGUI.ColorField(pos,(Color) x.GetValue()));
                _drawNonUnityValue<AnimationCurve>(ref rect,valueS, (pos,x) => EditorGUI.CurveField(pos,(AnimationCurve) x.GetValue()));
                _drawNonUnityValue<Bounds>(ref rect,valueS, (pos,x) => EditorGUI.BoundsField(pos,(Bounds) x.GetValue()));
                _drawNonUnityValue<BoundsInt>(ref rect,valueS, (pos,x) => EditorGUI.BoundsIntField(pos,(BoundsInt) x.GetValue()));
                _drawNonUnityValue<Rect>(ref rect,valueS, (pos,x) => EditorGUI.RectField(pos,(Rect) x.GetValue()));
                _drawNonUnityValue<RectInt>(ref rect,valueS, (pos,x) => EditorGUI.RectIntField(pos,(RectInt) x.GetValue()));
                _drawNonUnityValue<Enum>(ref rect,valueS, (pos,x) => EditorGUI.EnumFlagsField(pos,(Enum) x.GetValue()));
                _drawNonUnityValue<Gradient>(ref rect,valueS, (pos,x) => EditorGUI.GradientField(pos,(Gradient) x.GetValue()));
                
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

        void _drawNonUnityValue<T>(ref  Rect rect,ValueS valueS, Func<Rect,ValueS,object> drawAction)
        {
            if (!typeof(T).IsAssignableFrom(valueS.ValueType))
            {
                return;
            }
            
            var offset = new Vector2(15,0);
            rect.position -= offset; //subtract offset
            
            rect.size -= new Vector2(10,0);
            
            var value = drawAction(rect,valueS);
            
            rect.position += new Vector2(rect.size.x + 10,0);
            
            if (GUI.changed)
            {
                valueS.SetValue(value);
                Save();
            }
        }
    }
}