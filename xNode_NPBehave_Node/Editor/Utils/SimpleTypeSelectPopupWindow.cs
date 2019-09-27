using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils
{
    public class TypeSelectPopupWindow : PopupWindowContent
    {
        private readonly bool _focus;
        private Type _baseType;
        private string _ser;
        private SearchField searchField;
        public TypeSelectPopupWindow(bool focus):this(focus,typeof(object)) { }

        public TypeSelectPopupWindow(bool focus,Type baseType)
        {
            this._focus = focus;
            this.BaseType = baseType;
            var typs = TypeUtil.UnityRuntimeTypes.Where(x=> BaseType.IsAssignableFrom(x));
            _typeGroup = typs.GroupBy(x => x.Assembly);
        }

        public Type BaseType
        {
            get => _baseType;
            set => _baseType = value;
        }

        public override void OnOpen()
        {
            base.OnOpen();
            searchField = new SearchField();
            _state = new List<bool>();

            if (_focus)
            {
                searchField.SetFocus();
            }
        }

        public override void OnClose()
        {
            base.OnClose();
            //todo 不清空吧=-=
            //_ser = string.Empty;
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
                    if (!string.IsNullOrWhiteSpace(_ser) &&
                        !valueType.FullName.ToLower().Contains(_ser.ToLower()) ||
                        BaseType != null && !BaseType.IsAssignableFrom(valueType))
                    {
                        isSkip = true;
                    }
                    else
                    {
                        isSkip = false;
                    }
                }

                if (isSkip)
                {
                    continue;
                }

                var assemblyPath = group.Key.ConversionAssemblyName();
                
                _state[i] = EditorGUILayout.Foldout(_state[i],assemblyPath , true);

                if (_state[i])
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(1*20);
                    GUILayout.BeginVertical();
                    foreach (var valueType in @group)
                    {
                        if (!string.IsNullOrWhiteSpace(_ser) || BaseType != null)
                        {
                            if (!string.IsNullOrWhiteSpace(_ser) &&
                                !valueType.FullName.ToLower().Contains(_ser.ToLower()) ||
                                !BaseType.IsAssignableFrom(valueType))
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