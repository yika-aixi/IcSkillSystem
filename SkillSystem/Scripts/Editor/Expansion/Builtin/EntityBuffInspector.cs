using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using UnityEditor;

namespace CabinIcarus.IcSkillSystem.Expansion.Editors.Builtin.Buffs.Unity
{
    [CustomEditor(typeof(BuffEntityLinkComponent))]
    public class EntityBuffInspector : Editor
    {
        private BuffEntityLinkComponent _entityBuff;
        private List<IBuffDataComponent> _buffs;
        private List<bool> _foldoutState;
        private void OnEnable()
        {
            _entityBuff = (BuffEntityLinkComponent) target;
            _buffs = new List<IBuffDataComponent>();
            _foldoutState = new List<bool>();
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

            _entityBuff.BuffManager.GetBuffs(_entityBuff.Entity,_buffs);

            if (_foldoutState.Count < _buffs.Count)
            {
                for (var i = _foldoutState.Count; i < _buffs.Count; i++)
                {
                    _foldoutState.Add(false);
                }
            }
            
            EditorGUILayout.LabelField($"Buff数量:{_buffs.Count}");

            for (var i = 0; i < _buffs.Count; i++)
            {
                var buff = _buffs[i];
                
                var fields = buff.GetType().GetFields();
                var properties = buff.GetType().GetProperties();

                _foldoutState[i] = EditorGUILayout.Foldout(_foldoutState[i], $"{buff.GetType().Name}",true);

                if (!_foldoutState[i])
                {
                    continue;
                }

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
            
            Repaint();
        }
    }
}