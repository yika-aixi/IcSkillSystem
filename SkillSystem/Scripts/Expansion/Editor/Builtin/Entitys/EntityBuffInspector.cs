using System;
using System.Collections.Generic;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Editor;
using CabinIcarus.IcSkillSystem.Expansion.Builtin.Component;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Editors.Builtin.Entitys
{
    struct BuffInfo
    {
        public IBuffDataComponent Buff;
        public int Index;

        public BuffInfo(IBuffDataComponent buff, int index)
        {
            Buff = buff;
            Index = index;
        }
    }
    [CustomEditor(typeof(BuffEntityLinkComponent))]
    public class EntityBuffInspector : UnityEditor.Editor
    {
        private BuffEntityLinkComponent _entityBuff;
        private Dictionary<Type, List<BuffInfo>> _buffGroup;
        private List<bool> _foldoutState1;
        private List<bool> _foldoutState2;
        private List<IBuffDataComponent> _buffs;

        private void OnEnable()
        {
            _entityBuff = (BuffEntityLinkComponent) target;
            _buffGroup = new Dictionary<Type, List<BuffInfo>>();
            _foldoutState1 = new List<bool>();
            _foldoutState2 = new List<bool>();
            _buffs = new List<IBuffDataComponent>();
            
            ABuffDebugWindow<IcSkSEntity>.EntityManager = _entityBuff.EntityManager;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (_entityBuff.EntityManager == null)
            {
                EditorGUILayout.HelpBox($"没有初始化!请调用{nameof(BuffEntityLinkComponent.Init)}", MessageType.Warning);
                return;
            }

            if (_entityBuff.IcSkSEntity == null)
            {
                EditorGUILayout.HelpBox($"没有连接实体!请调用{nameof(BuffEntityLinkComponent.Link)}", MessageType.Warning);
                return;
            }

            _buffs.Clear();
            _buffGroup.Clear();
            
            var buffs = _entityBuff.EntityManager.BuffManager.GetAllBuff(_entityBuff.IcSkSEntity);
            
            _buffs.AddRange(buffs);

            if (_buffs.Count == 0)
            {
                Repaint();
                return;
            }

            int index = 0;
            Type lastBuffType = null;
            for (var i = 0; i < _buffs.Count; i++)
            {
                var buff = _buffs[i];

                if (lastBuffType == null || lastBuffType != buff.GetType())
                {
                    lastBuffType = buff.GetType();
                    index = 0;
                }
                
                if (!_buffGroup.ContainsKey(buff.GetType()))
                {
                    _buffGroup.Add(buff.GetType(), new List<BuffInfo>());
                }

                _buffGroup[buff.GetType()].Add(new BuffInfo(buff,index));

                index++;
            }

            EditorGUILayout.LabelField($"Buff同类数量:{_buffGroup.Count}");

            if (_foldoutState1.Count < _buffGroup.Count)
            {
                for (var i = _foldoutState1.Count; i < _buffGroup.Count; i++)
                {
                    _foldoutState1.Add(false);
                }
            }

            index = 0;
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
                    var buffInfo = buffP.Value[j];
                    var buff = buffInfo.Buff;
                    EditorGUILayout.BeginHorizontal();
                    {
                        if (buffP.Value.Count > 1)
                            _foldoutState2[j] = EditorGUILayout.Foldout(_foldoutState2[j], $"Index: {j}", true);
                        else
                        {
                            _foldoutState2[j] = EditorGUILayout.Foldout(_foldoutState2[j], $"{buffP.Key.Name}", true);
                        }

                        var icon = EditorGUIUtility.FindTexture("d_P4_DeletedLocal");
                        EditorGUIUtility.SetIconSize(new Vector2(icon.width,icon.height));
                        if (GUILayout.Button(icon,GUILayout.Width(icon.width + 2),GUILayout.Height(icon.height + 2)))
                        {
                            _entityBuff.EntityManager.RemoveBuff(_entityBuff.IcSkSEntity, buff);
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                    
                    if (_foldoutState2[j])
                    {
                        MemberInfo[] fields = buff.GetType().GetFields();
                        MemberInfo[] properties = buff.GetType().GetProperties();
                        EditorGUI.indentLevel++;
                        {
                            _memberInfoDraw(fields, buffInfo, (info, component) => ((FieldInfo) info).GetValue(component),
                                (info => true), 
                                (info, component, value) => ((FieldInfo) info).SetValue(component, value));

                            _memberInfoDraw(properties, buffInfo, (info, component) => ((PropertyInfo) info).GetValue(component),
                                (info => ((PropertyInfo) info).CanWrite), 
                                (info, component, value) =>
                                {
                                    var oldValue = ((PropertyInfo) info).GetValue(component);
                                    
                                    ((PropertyInfo) info).SetValue(component, value);
                                    
                                    var newValue = ((PropertyInfo) info).GetValue(component);

                                    if (oldValue.Equals(newValue))
                                    {
                                        Debug.LogError("Property `Set` Function is Null implement");
                                    }
                                });
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

        private void _memberInfoDraw(MemberInfo[] fields, BuffInfo buff,
            Func<MemberInfo, IBuffDataComponent, object> getValue,
            Func<MemberInfo,bool> isSet,
            Action<MemberInfo, IBuffDataComponent, object> setValue)
        {
            foreach (var info in fields)
            {
                var infoValue = getValue(info, buff.Buff);

                GUIContent title = new GUIContent($"{info.Name}");
                
                if (!isSet(info))
                {
                    EditorGUILayout.LabelField($"{info.Name}:{infoValue}");
                    continue;
                }

                GUI.changed = false;
                
                switch (infoValue)
                {
                    case string value:
                        
                        value = EditorGUILayout.DelayedTextField(title, value);

                        if (GUI.changed)
                        {
                            setValue(info, buff.Buff, value);
                            _entityBuff.EntityManager.BuffManager.SetBuffData(_entityBuff.IcSkSEntity,buff.Buff,buff.Index);
                            GUI.changed = false;
                        }

                        continue;
                    case int value:
                        value = EditorGUILayout.DelayedIntField(title, value);
                        if (GUI.changed)
                        {
                            setValue(info, buff.Buff, value);
                            _entityBuff.EntityManager.BuffManager.SetBuffData(_entityBuff.IcSkSEntity,buff.Buff,buff.Index);
                            GUI.changed = false;
                        }

                        continue;
                    case float value:
                        value = EditorGUILayout.DelayedFloatField(title, value);
                        if (GUI.changed)
                        {
                            setValue(info, buff.Buff, value);
                            _entityBuff.EntityManager.BuffManager.SetBuffData(_entityBuff.IcSkSEntity,buff.Buff,buff.Index);
                            GUI.changed = false;
                        }

                        continue;
                    case bool value:
                        value = EditorGUILayout.Toggle(title, value);
                        if (GUI.changed)
                        {
                            setValue(info, buff.Buff, value);
                            _entityBuff.EntityManager.BuffManager.SetBuffData(_entityBuff.IcSkSEntity,buff.Buff,buff.Index);
                            GUI.changed = false;
                        }

                        continue;
                    case Enum value:
                        value = EditorGUILayout.EnumPopup(title, value);
                        if (GUI.changed)
                        {
                            setValue(info, buff.Buff, value);
                            _entityBuff.EntityManager.BuffManager.SetBuffData(_entityBuff.IcSkSEntity,buff.Buff,buff.Index);
                            GUI.changed = false;
                        }

                        continue;
                }
                
                
            }
            
            
        }
    }
}