using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Editors.Builtin.Buffs.Unity
{
    [CustomEditor(typeof(BuffEntityLinkComponent))]
    public class EntityBuffInspector : Editor
    {
        private BuffEntityLinkComponent _entityBuff;
        private Dictionary<Type, List<IBuffDataComponent>> _buffGroup;
        private List<bool> _foldoutState1;
        private List<bool> _foldoutState2;

        private void OnEnable()
        {
            _entityBuff = (BuffEntityLinkComponent) target;
            _buffGroup = new Dictionary<Type, List<IBuffDataComponent>>();
            _foldoutState1 = new List<bool>();
            _foldoutState2 = new List<bool>();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (_entityBuff.BuffManager == null)
            {
                EditorGUILayout.HelpBox($"没有初始化!请调用{nameof(BuffEntityLinkComponent.Init)}", MessageType.Warning);
                return;
            }

            if (_entityBuff.Entity == null)
            {
                EditorGUILayout.HelpBox($"没有连接实体!请调用{nameof(BuffEntityLinkComponent.Link)}", MessageType.Warning);
                return;
            }

            var buffs = _entityBuff.BuffManager.GetBuffs<IBuffDataComponent>(_entityBuff.Entity);
            _buffGroup.Clear();

            if (buffs == null)
            {
                Repaint();
                return;
            }

            foreach (var buff in buffs)
            {
                if (!_buffGroup.ContainsKey(buff.GetType()))
                {
                    _buffGroup.Add(buff.GetType(), new List<IBuffDataComponent>());
                }

                _buffGroup[buff.GetType()].Add(buff);
            }
            
            EditorGUILayout.LabelField($"Buff同类数量:{_buffGroup.Count}");

            if (_foldoutState1.Count < _buffGroup.Count)
            {
                for (var i = _foldoutState1.Count; i < _buffGroup.Count; i++)
                {
                    _foldoutState1.Add(false);
                }
            }

            int index = 0;
            foreach (var buffP in _buffGroup)
            {
                if (buffP.Value.Count > 1)
                {
                    _foldoutState1[index] =
                        EditorGUILayout.Foldout(_foldoutState1[index], $"{buffP.Key.Name} Buffs", true);

                    if (!_foldoutState1[index])
                    {
                        continue;
                    }
                    EditorGUILayout.BeginVertical("box");
                    EditorGUI.indentLevel++;
                }

                if (_foldoutState2.Count < buffP.Value.Count)
                {
                    for (var i = _foldoutState2.Count; i < buffP.Value.Count; i++)
                    {
                        _foldoutState2.Add(false);
                    }
                }

                for (var j = 0; j < buffP.Value.Count; j++)
                {
                    var buff = buffP.Value[j];

                    if (buffP.Value.Count > 1)
                        _foldoutState2[j] = EditorGUILayout.Foldout(_foldoutState2[j], $"Index: {j}", true);
                    else
                    {
                        _foldoutState2[j] = EditorGUILayout.Foldout(_foldoutState2[j], $"{buffP.Key.Name}", true);
                    }

                    if (_foldoutState2[j])
                    {
                        MemberInfo[] fields = buff.GetType().GetFields();
                        MemberInfo[] properties = buff.GetType().GetProperties();
                        EditorGUI.indentLevel++;
                        {
                            _memberInfoDraw(fields, buff, (info, component) => ((FieldInfo) info).GetValue(component),
                                (info => true), 
                                (info, component, value) => ((FieldInfo) info).SetValue(component, value));

                            _memberInfoDraw(properties, buff, (info, component) => ((PropertyInfo) info).GetValue(component),
                                (info => ((PropertyInfo) info).CanWrite), 
                                (info, component, value) => ((PropertyInfo) info).SetValue(component, value));
                        }
                        EditorGUI.indentLevel--;
                    }
                }

                if (buffP.Value.Count > 1)
                {
                    EditorGUILayout.EndVertical();
                    EditorGUI.indentLevel--;
                }

                ++index;
            }

            Repaint();
        }

        private void _memberInfoDraw(MemberInfo[] fields, IBuffDataComponent buff,
            Func<MemberInfo, IBuffDataComponent, object> getValue,
            Func<MemberInfo,bool> isSet,
            Action<MemberInfo, IBuffDataComponent, object> setValue)
        {
            foreach (var info in fields)
            {
                var infoValue = getValue(info, buff);

                GUIContent title = new GUIContent($"{info.Name}");
                
                if (!isSet(info))
                {
                    EditorGUILayout.LabelField($"{info.Name}:{infoValue}");
                    continue;
                }
                
                switch (infoValue)
                {
                    case string value:
                        
                        value = EditorGUILayout.DelayedTextField(title, value);

                        if (GUI.changed)
                        {
                            setValue(info, buff, value);
                            GUI.changed = false;
                        }

                        continue;
                    case int value:
                        value = EditorGUILayout.DelayedIntField(title, value);
                        if (GUI.changed)
                        {
                            setValue(info, buff, value);
                            GUI.changed = false;
                        }

                        continue;
                    case float value:
                        value = EditorGUILayout.DelayedFloatField(title, value);
                        if (GUI.changed)
                        {
                            setValue(info, buff, value);
                            GUI.changed = false;
                        }

                        continue;
                    case bool value:
                        value = EditorGUILayout.Toggle(title, value);
                        if (GUI.changed)
                        {
                            setValue(info, buff, value);
                            GUI.changed = false;
                        }

                        continue;
                    case Enum value:
                        value = EditorGUILayout.EnumPopup(title, value);
                        if (GUI.changed)
                        {
                            setValue(info, buff, value);
                            GUI.changed = false;
                        }

                        continue;
                }
            }
        }
    }
}