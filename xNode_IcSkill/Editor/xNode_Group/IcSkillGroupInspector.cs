using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    [CustomEditor(typeof(IcSkillGroup))]
    public class IcSkillGroupInspector : UnityEditor.Editor
    {
        private SerializedProperty _serializedSer;
        private IcSkillGroup _group;
        
        private void OnEnable()
        {
            _group = (IcSkillGroup) target;
            _serializedSer = serializedObject.FindProperty(IcSkillGroup.SerializeFieldName);
            _des();
        }

        private void _des()
        {
            var str = _serializedSer.stringValue;
            
            if (!string.IsNullOrEmpty(str))
            {
                _group.VariableMap = SerializationUtil.ToValue<Dictionary<string, ValueS>>(str);
            }
        }
        
        private void _ser()
        {
            _serializedSer.stringValue = SerializationUtil.ToString(_group.VariableMap);
        }

        void _save()
        {
            _ser();
            _des();
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
                        _group.VariableMap.Add(string.Empty, new ValueS());
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

                            if (string.IsNullOrWhiteSpace(value.ValueTypeAqName))
                            {
                                _drawValueTypeSelect(key,value);
                            }
                            else
                            {
                                _drawValue(key,value);
                            }
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUI.indentLevel--;
        }

        private void _drawValueTypeSelect(string key, ValueS value)
        {
            //todo draw Value Type Select
            
        }

        private void _drawValue(string key, ValueS value)
        {
            //todo draw Value
        }
    }
}