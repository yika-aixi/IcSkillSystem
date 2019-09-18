using System;
using System.Collections.Generic;
using System.Linq;
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
                EditorGUILayout.HelpBox($"没有初始化!请调用{nameof(BuffEntityLinkComponent.Init)}",MessageType.Warning);
                return;
            }
            
            if (_entityBuff.Entity == null)
            {
                EditorGUILayout.HelpBox($"没有连接实体!请调用{nameof(BuffEntityLinkComponent.Link)}",MessageType.Warning);
                return;
            }

            var buffs = _entityBuff.BuffManager.GetBuffs<IBuffDataComponent>(_entityBuff.Entity);
            _buffGroup.Clear();
            EditorGUILayout.LabelField($"Buff同类数量:{_buffGroup.Count}");
            
            if (buffs == null)
            {
                Repaint();
                return;
            }
            
            foreach (var buff in buffs)
            {
                if (!_buffGroup.ContainsKey(buff.GetType()))
                {
                    _buffGroup.Add(buff.GetType(),new List<IBuffDataComponent>());
                }

                _buffGroup[buff.GetType()].Add(buff);
            }
            
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
                    _foldoutState1[index] = EditorGUILayout.Foldout(_foldoutState1[index], $"{buffP.Key.Name} Buffs",true);
                    
                    if (!_foldoutState1[index])
                    {
                        continue;
                    }
                    
                    EditorGUI.indentLevel++;
                }
                
                if (_foldoutState2.Count < buffP.Value.Count)
                {
                    for (var i = _foldoutState2.Count; i < buffP.Value.Count; i++)
                    {
                        _foldoutState2.Add(false);
                    }
                }
                Debug.LogError(_foldoutState2.Count);
                for (var j = 0; j < buffP.Value.Count; j++)
                {
                    var buff = buffP.Value[j];
                    
                    if (buffP.Value.Count > 1)
                        _foldoutState2[j] = EditorGUILayout.Foldout(_foldoutState2[j], $"Index: {j}",true);
                    else
                    {
                        _foldoutState2[j] = EditorGUILayout.Foldout(_foldoutState2[j], $"{buffP.Key.Name}",true);
                    }

                    if ( _foldoutState2[j])
                    {
                        var fields = buff.GetType().GetFields();
                        var properties = buff.GetType().GetProperties();
                        
                        EditorGUI.indentLevel++;
                        {
                            foreach (var field in fields)
                            {
                                EditorGUILayout.LabelField($"{field.Name}:{field.GetValue(buff)}");
                            }

                            foreach (var property in properties)
                            {
                                EditorGUILayout.LabelField($"{property.Name}:{property.GetValue(buff)}");
                            }
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
    }
}