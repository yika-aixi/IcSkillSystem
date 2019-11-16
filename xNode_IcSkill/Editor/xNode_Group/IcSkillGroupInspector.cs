using System;
using System.Linq;
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

        private void OnEnable()
        {
            if (_types == null)
            {
                _types = TypeAQNameSelect.Types.ToArray();                
            }
            
            _group = (IcSkillGroup) target;
            _keysSer = serializedObject.FindProperty(IcSkillGroup.KeysName);
            _valuesSer = serializedObject.FindProperty(IcSkillGroup.ValuesName);
            _des();
        }

        private void _des()
        {
//            var str = _serializedSer.stringValue;
            
//            if (!string.IsNullOrEmpty(str))
            {
                //_group.VariableMap = SerializationUtil.ToValue<Dictionary<string, ValueS>>(str);
            }
        }
        
        private void _ser()
        {
            //_serializedSer.stringValue = SerializationUtil.ToString(_group.VariableMap);
        }

        void _save()
        {
//            _ser();
//            _des();
            EditorUtility.SetDirty(target);
        }

        public override void OnInspectorGUI()
        {
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

                            if (GUILayout.Button(new GUIContent(EditorGUIUtility.FindTexture("Refresh"),"Change Type")))
                            {
                                value.ValueType = null;
                                _save();
                            }

                            if (GUILayout.Button(new GUIContent(EditorGUIUtility.FindTexture("d_P4_DeletedLocal"),"Remove Item")))
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
            //todo draw Value Type Select
            int index = 0;
            
            EditorGUI.BeginChangeCheck();
            
            var type = TypeAQNameSelect.DrawSelectPopType(new GUIContent(), ref index, _types);
            
            if (EditorGUI.EndChangeCheck())
            {
                value.ValueType = type;
                _save();
            }
        }

        private void _drawValue(IcSkillGroup.ValueS value)
        {
            //todo draw Value
            if (value.IsUnity)
            {
                Object obj;
                EditorGUI.BeginChangeCheck();
                {
                    obj = EditorGUILayout.ObjectField(value.UValue, value.ValueType, false);
                }
                if (EditorGUI.EndChangeCheck())
                {
                    value.SetValue(obj);
                    _save();
                }
            }
            else
            {
                //todo non Unity Type
//                EditorGUILayout.field
            }
        }
    }
}