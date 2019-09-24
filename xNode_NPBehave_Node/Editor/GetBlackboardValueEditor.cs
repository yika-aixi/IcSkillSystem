using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
//    [NodeEditor.CustomNodeEditorAttribute(typeof(GetBlackboardValue))]
    public class GetBlackboardValueEditor:NodeEditor
    {
        private _typeSelecrPopupWindow windowContent;
        private Type _selectType;

        public override void OnCreate()
        {
            base.OnCreate();
            windowContent = new _typeSelecrPopupWindow();
            windowContent.OnChangeTypeSelect = type =>
            {
                var fieldName = GetBlackboardValue.TypeValueOutPortName;
                
                if (_selectType != null)
                {
                    if (target.GetPort(fieldName) != null)
                    {
                        target.RemoveDynamicPort(fieldName);
                    }
                }

                _selectType = type;

                target.AddDynamicOutput(_selectType, fieldName: fieldName);
                
                windowContent.editorWindow.Close();
            };
        }

        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
            
            if (GUILayout.Button("Open"))
            {
                UnityEditor.PopupWindow.Show(new Rect(GetCurrentMousePosition(),new Vector2(500,300)), windowContent);
            }
        }
    }
    
    public class _typeSelecrPopupWindow : PopupWindowContent
    {
        private readonly Type _baseType;
        private string _ser;
        private SearchField searchField;

        public _typeSelecrPopupWindow():this(typeof(object))
        {
        }

        public _typeSelecrPopupWindow(Type baseType)
        {
            this._baseType = baseType;
            var typs = TypeUtil.RuntimeTypes;
            _typeGroup = typs.GroupBy(x => x.Assembly);
        }

        public override void OnOpen()
        {
            base.OnOpen();
            searchField = new SearchField();
            _state = new List<bool>();
        }

        public Action<Type> OnChangeTypeSelect;

        private Vector2 _pos;
        private List<bool> _state;
        private IEnumerable<IGrouping<Assembly, Type>> _typeGroup;

        public override void OnGUI(Rect rect)
        {
            _ser = searchField.OnGUI(new Rect(rect.position,new Vector2(rect.width,20)), _ser);

            if (GUI.changed)
            {
                for (var i1 = 0; i1 < _state.Count; i1++)
                {
                    _state[i1] = false;
                }
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            _pos = EditorGUILayout.BeginScrollView(_pos);
            int i = 0;
            foreach (var group in _typeGroup)
            {
                if (_state.Count <= i)
                {
                    _state.Add(false);
                }

                bool isSkip = false;
                foreach (var valueType in @group)
                {
                    if (!string.IsNullOrWhiteSpace(_ser) || _baseType != null)
                    {
                        if (!string.IsNullOrWhiteSpace(_ser) &&
                            !valueType.FullName.ToLower().Contains(_ser.ToLower()) ||
                            !_baseType.IsAssignableFrom(valueType))
                        {
                            isSkip = true;
                        }
                        else
                        {
                            isSkip = false;
                        }
                    }
                }

                if (isSkip)
                {
                    continue;
                }

                _state[i] = EditorGUILayout.Foldout(_state[i], group.Key.GetName().Name, true);

                if (_state[i])
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(1*20);
                    GUILayout.BeginVertical();
                    foreach (var valueType in @group)
                    {
                        if (!string.IsNullOrWhiteSpace(_ser) || _baseType != null)
                        {
                            if (!string.IsNullOrWhiteSpace(_ser) &&
                                !valueType.FullName.ToLower().Contains(_ser.ToLower()) ||
                                !_baseType.IsAssignableFrom(valueType))
                            {
                                continue;
                            }
                        }

                        if (GUILayout.Button(valueType.Name,"label"))
                        {
                            OnChangeTypeSelect?.Invoke(valueType);
                        }
                    }
                    GUILayout.EndVertical();
                    GUILayout.EndHorizontal();
                }
                ++i;
            }
           
            EditorGUILayout.EndScrollView();
        }
    }
}