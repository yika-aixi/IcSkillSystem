using System;
using System.Linq;
using CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils;
using SkillSystem.xNode_IcSkill.Editor.Util;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    [CustomEditor(typeof(IcSkillGroup))]
    public class IcSkillGroupInspector : UnityEditor.Editor
    {
        private SerializedProperty _keysSer;
        private SerializedProperty _valuesSer;
        
        private IcSkillGroup _group;

        private static Type[] _types;

        private static ValueEditPopupWindow _ValueEditPopup;
        private static SimpleTypeSelectPopupWindow _SimpleTypeSelect;
        private Rect _rect;

        private void OnEnable()
        {
            if (_types == null)
            {
                _types = TypeAQNameSelect.Types.ToArray();                
                _ValueEditPopup = new ValueEditPopupWindow();
                _ValueEditPopup.OnEdit = _save;
                _SimpleTypeSelect = new SimpleTypeSelectPopupWindow(true,_types);

            }
            
            _group = (IcSkillGroup) target;
            _keysSer = serializedObject.FindProperty(IcSkillGroup.KeysName);
            _valuesSer = serializedObject.FindProperty(IcSkillGroup.ValuesName);
        }

        void _save()
        {
            EditorUtility.SetDirty(target);
        }

        public override void OnInspectorGUI()
        {
            if (EditorWindow.mouseOverWindow)
            {
                _rect = EditorWindow.mouseOverWindow.position;
            }

            serializedObject.Update();
            {
                _drawBlackboardVar();
            }
            serializedObject.ApplyModifiedProperties();
        }

        private bool _showBlackboard;
        
        private void _drawBlackboardVar()
        {
            _showBlackboard = EditorGUILayout.Foldout(_showBlackboard, "Blackboard Variable",true);

            if (!_showBlackboard)
            {
                return;
            }

            EditorGUI.indentLevel++;
            {
                EditorGUILayout.BeginVertical("box");
                {
                    if (GUILayout.Button("Add Variable"))
                    {
                        _group.VariableMap.Add(_group.VariableMap.Count.ToString(), new IcSkillGroup.ValueS());
                    }

                    var keys = _group.VariableMap.Keys.ToList();

                    foreach (var key in keys)
                    {
                        var value = _group.VariableMap[key];

                        EditorGUILayout.BeginHorizontal();
                        {
                            string newKey;

                            EditorGUI.BeginChangeCheck();
                            {
                                newKey = EditorGUILayout.DelayedTextField(key);
                            }
                            if (EditorGUI.EndChangeCheck())
                            {
                                if (!string.IsNullOrEmpty(newKey))
                                {
                                    _group.VariableMap.Remove(key);
                                    _group.VariableMap.Add(newKey, value);
                                    _save();
                                }
                            }

                            if (value.ValueType == null)
                            {
                                _drawValueTypeSelect(value);
                            }
                            else
                            {
                                _drawValue(value);
                            }

                            if (value.ValueType != null)
                            {
                                if (GUILayout.Button(new GUIContent(EditorGUIUtility.FindTexture("Refresh"),$"Change Type,Current Type:{value.ValueType.FullName}"),
                                    GUILayout.Width(26)))
                                {
                                    value.ValueType = null;
                                    value.SetValue(null);
                                    _save();
                                    return;
                                }
                            }

                            if (GUILayout.Button(new GUIContent(EditorGUIUtility.FindTexture("d_P4_DeletedLocal"),"Remove Item"),GUILayout.Width(26)))
                            {
                                _group.VariableMap.Remove(key);
                                _save();
                            }
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUI.indentLevel--;
        }

        private void _drawValueTypeSelect(IcSkillGroup.ValueS value)
        {
            if (GUILayout.Button(new GUIContent("Ｔ","Select Type")))
            {
                _SimpleTypeSelect.OnChangeTypeSelect = type =>
                {
                    value.ValueType = type;
                    _save();
                    _SimpleTypeSelect.editorWindow.Close();
                };
                
                var size = 250;

                PopupWindow.Show(
                    new Rect(new Vector2(Event.current.mousePosition.x - size / 2, -(_rect.height - size - (Event.current.mousePosition.y + 60)) )
                        ,new Vector2(size,size)),
                    _SimpleTypeSelect);
            }

        }

        private void _drawValue(IcSkillGroup.ValueS valueS)
        {
            //todo draw Value
            if (valueS.IsUnity)
            {
                Object obj;
                EditorGUI.BeginChangeCheck();
                {
                    obj = EditorGUILayout.ObjectField(valueS.UValue, valueS.ValueType, false);
                }
                if (EditorGUI.EndChangeCheck())
                {
                    valueS.SetValue(obj);
                    _save();
                }
            }
            else
            {
                //todo non Unity Type

                var value = valueS.GetValue();

                if (value == null)
                {
                    valueS.SetValue(Activator.CreateInstance(valueS.ValueType));
                    _save();
                }

               
                _drawNonUnityValue<int>(valueS, x => EditorGUILayout.DelayedIntField((int) x.GetValue()));
                _drawNonUnityValue<float>(valueS, x => EditorGUILayout.DelayedFloatField((float) x.GetValue()));
                _drawNonUnityValue<double>(valueS, x => EditorGUILayout.DelayedDoubleField((double) x.GetValue()));
                _drawNonUnityValue<long>(valueS, x => EditorGUILayout.LongField((long) x.GetValue()));
                _drawNonUnityValue<string>(valueS, x => EditorGUILayout.DelayedTextField((string) x.GetValue()));
                _drawNonUnityValue<Vector2>(valueS, x => EditorGUILayout.Vector2Field("",(Vector2) x.GetValue()));
                _drawNonUnityValue<Vector2Int>(valueS, x => EditorGUILayout.Vector2IntField("",(Vector2Int) x.GetValue()));
                _drawNonUnityValue<Vector3>(valueS, x => EditorGUILayout.Vector3Field("",(Vector3) x.GetValue()));
                _drawNonUnityValue<Vector3Int>(valueS, x => EditorGUILayout.Vector3IntField("",(Vector3Int) x.GetValue()));
                _drawNonUnityValue<Vector4>(valueS, x => EditorGUILayout.Vector4Field("",(Vector4) x.GetValue()));
                _drawNonUnityValue<Color>(valueS, x => EditorGUILayout.ColorField((Color) x.GetValue()));
                _drawNonUnityValue<AnimationCurve>(valueS, x => EditorGUILayout.CurveField((AnimationCurve) x.GetValue()));
                _drawNonUnityValue<Bounds>(valueS, x => EditorGUILayout.BoundsField((Bounds) x.GetValue()));
                _drawNonUnityValue<BoundsInt>(valueS, x => EditorGUILayout.BoundsIntField((BoundsInt) x.GetValue()));
                _drawNonUnityValue<Rect>(valueS, x => EditorGUILayout.RectField((Rect) x.GetValue()));
                _drawNonUnityValue<RectInt>(valueS, x => EditorGUILayout.RectIntField((RectInt) x.GetValue()));
                _drawNonUnityValue<Enum>(valueS, x => EditorGUILayout.EnumFlagsField((Enum) x.GetValue()));
                _drawNonUnityValue<Gradient>(valueS, x => EditorGUILayout.GradientField((Gradient) x.GetValue()));

                if (GUILayout.Button("Edit Value"))
                {
                    var size = 250;

                    _ValueEditPopup.ValueS = valueS;

                    PopupWindow.Show(
                        new Rect(new Vector2( Event.current.mousePosition.x - size / 2, -(_rect.height - size - (Event.current.mousePosition.y + 60)) )
                            ,new Vector2(size,size)),
                        _ValueEditPopup);
                }
            }
        }

        void _drawNonUnityValue<T>(IcSkillGroup.ValueS valueS, Func<IcSkillGroup.ValueS,object> drawAction)
        {
            if (!typeof(T).IsAssignableFrom(valueS.ValueType))
            {
                return;
            }
            
            var value = drawAction(valueS);
            
            if (GUI.changed)
            {
                valueS.SetValue(value);
                
                _save();
            }
        }
    }
}