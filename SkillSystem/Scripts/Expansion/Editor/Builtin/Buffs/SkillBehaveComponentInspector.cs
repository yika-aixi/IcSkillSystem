using System;
using System.Linq;
using CabinIcarus.IcSkillSystem.Expansion.Builtin.Skills.Component;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Editors.Builtin.Buffs
{
    [CustomEditor(typeof(SkillBehaveComponent),true)]
    public class SkillBehaveComponentInspector : UnityEditor.Editor
    {
        private IcSkillGroup _lastGroup;
        private SkillBehaveComponent _target;
        private void OnEnable()
        {
            _target = (SkillBehaveComponent) target;

            _lastGroup = _target.Group;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            {
                if (_lastGroup != _target.Group)
                {
                    _lastGroup = _target.Group;
                    
                    //remove
                    foreach (var key in _target.Data.Keys.ToList())
                    {
                        if (!_lastGroup.VariableMap.ContainsKey(key))
                        {
                            _target.Data.Remove(key);
                        }
                    }
                    
                    //update
                    foreach (var pair in _lastGroup.VariableMap)
                    {
                        if (!_target.Data.TryGetValue(pair.Key,out var values))
                        {
                            _target.Data.Add(pair.Key,new ValueS(pair.Value));
                        }
                        else
                        {
                            if (values.ValueType != pair.Value.ValueType)
                            {
                                values.SetValue(null,pair.Value.ValueType);
                                values.ValueType = pair.Value.ValueType;
                            }
                        }
                    }
                }

                base.OnInspectorGUI();
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}