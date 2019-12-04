using System;
using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.Editor;
using CabinIcarus.IcSkillSystem.Editor.Utils;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Utils;
using UnityEditor;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">ANPNode 节点</typeparam>
    /// <typeparam name="AT">输出类型</typeparam>
    public abstract class AQNameSelectEditor<T,AT>:ANPNodeEditor<T,AT> where T : ANPNode<AT>
    {
        class TypeInfo
        {
            public string Name;
            public Type Type;

            public TypeInfo(string name, Type type)
            {
                Name = name;
                Type = type;
            }
        }
        
        protected SerializedProperty _aQNameProperty;
        private SimpleTypeSelectPopupWindow _typeSelectWindow;

        protected override IEnumerable<string> GetExcludesField()
        {
            var AQName = GetAQNamePropertyName();

            if (string.IsNullOrWhiteSpace(AQName))
            {
                return null;
            }
            
            return new[] {AQName};
        }

        protected override void Init()
        {
            _aQNameProperty = serializedObject.FindProperty(GetAQNamePropertyName());
            if (_aQNameProperty == null)
            {
                throw new NullReferenceException($"没有找到名为:'{GetAQNamePropertyName()}'的属性");
            }

            var types = TypeUtil.GetRuntimeFilterTypes
                .Where(x=> GetBaseType().IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            if (types.Count() == 0)
            {
                Debug.LogWarning($"No {GetBaseType()} Types");
                return;
            }

            _typeSelectWindow = new SimpleTypeSelectPopupWindow(true,types);
            
            _typeSelectWindow.OnChangeTypeSelect = type =>
            {
                _aQNameProperty.stringValue = type.AssemblyQualifiedName;
                serializedObject.ApplyModifiedProperties();
                UpdateDynamicPort();
            };
        }

        /// <summary>
        /// 基础类型
        /// </summary>
        /// <returns></returns>
        protected abstract Type GetBaseType();

        /// <summary>
        /// AQName 选择框
        /// </summary>
        /// <param name="title"></param>
        /// <param name="options"></param>
        protected void DrawSelectPop(GUIContent title,params GUILayoutOption[] options)
        {
            var size = 250;

            EditorGUILayout.BeginHorizontal();
            {
                var titleSize = EditorStyles.label.CalcSize(title);
                
                EditorGUILayout.LabelField(title,GUILayout.Width( titleSize.x));

                float width = GetWidth() - titleSize.x - 30;
                
                if (_typeSelectWindow != null)
                {
                    if (GUILayout.Button(_aQNameProperty.stringValue.Split(',')[0].Split('.').Last(),"popup",GUILayout.Width(width)))
                    {
                        PopupWindow.Show(
                            new Rect(new Vector2(Event.current.mousePosition.x - size / 2, size)
                                ,new Vector2(size + 150,size)),
                            _typeSelectWindow);
                    } 
                }
                else
                {
                    EditorGUILayout.LabelField(new GUIContent($"No Impl.",$"No {GetBaseType()} Impl."),style:"popup",GUILayout.Width(width));
                }
                
            }
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// 更新动节点
        /// </summary>
        protected void UpdateDynamicPort()
        {
            if (string.IsNullOrWhiteSpace(_aQNameProperty.stringValue))
            {
                return;
            }

            var dynamicPorts = GetDynamicPort();

            if (dynamicPorts == null)
            {
                return;
            }

            Type type = Type.GetType(_aQNameProperty.stringValue);

            if (type == null)
            {
                Debug.LogError($"无法找到类型:{_aQNameProperty.stringValue}");
                return;
            }
            
            var fields = type.GetFields();
            var properties = type.GetProperties();
            List<TypeInfo> memberInfos = new List<TypeInfo>();
            memberInfos.AddRange(fields.Select(x=> new TypeInfo(x.Name,x.FieldType)));
            memberInfos.AddRange(properties.Where(x=>x.CanWrite).Select(x=> new TypeInfo(x.Name,x.PropertyType)));

            var ctros = type.GetConstructors();
            if (ctros.Length > 0)
            {
                var defaultCtor =  ctros[0];
                var args = defaultCtor.GetParameters();
                memberInfos.AddRange(args.Select(x=> new TypeInfo(_getParameterName(x.Name),x.ParameterType)));
            }

            var inputs = new List<NodePort>();
            inputs.AddRange(dynamicPorts);
            
            _updateDynamicPort(inputs,memberInfos);
            
            serializedObject.UpdateIfRequiredOrScript();
        }

        public override Color GetTint()
        {
            Type type = Type.GetType(_aQNameProperty.stringValue);

            if (type == null)
            {
                Error = true;
            }
            else
            {
                var ctors = type.GetConstructors();
                if (ctors.Length > 0)
                {
                    var defaultCtor = ctors[0];
                    var args = defaultCtor.GetParameters();
                    foreach (var ctorArg in args)
                    {
                        var inputPort = TNode.GetInputPort(_getParameterName(ctorArg.Name));

                        if (!inputPort.IsConnected)
                        {
                            Error = true;
                        }
                    }
                }
            }
           
            return base.GetTint();
        }

        private string _getParameterName(string argName)
        {
            return xNodeExpansion.GetCtorParameterName(argName);
        }

        protected virtual IEnumerable<NodePort> GetDynamicPort()
        {
            return null;
        }

        #region 动态节点更新

        private void _updateDynamicPort(IEnumerable<NodePort> dynamicPort,IEnumerable<TypeInfo> typeInfos)
        {
            _removeNoExist(dynamicPort, typeInfos);

            _addDynamicPort(dynamicPort, typeInfos);
        }

        private void _addDynamicPort(IEnumerable<NodePort> dynamicPort, IEnumerable<TypeInfo> typeInfos)
        {
            //添加新的
            foreach (var info in typeInfos)
            {
                bool hit = false;
                foreach (var nodePort in dynamicPort)
                {
                    if (nodePort.ValueType == info.Type && nodePort.fieldName == info.Name)
                    {
                        hit = true;
                        break;
                    }
                }

                if (!hit)
                {
                    TNode.AddDynamicInput(info.Type, Node.ConnectionType.Override, fieldName: info.Name,typeConstraint:Node.TypeConstraint.Inherited);
                }
            }
        }

        private void _removeNoExist(IEnumerable<NodePort> dynamicPort, IEnumerable<TypeInfo> typeInfos)
        {
            //删除被不存在的
            foreach (var nodePort in dynamicPort)
            {
                bool hit = false;
                foreach (var info in typeInfos)
                {
                    if (nodePort.ValueType == info.Type && nodePort.fieldName == info.Name)
                    {
                        hit = true;
                        break;
                    }
                }

                if (!hit)
                {
                    TNode.RemoveDynamicPort(nodePort);
                }
            }
        }

        #endregion

        protected override void ColorCheck()
        {
        }

        protected abstract string GetAQNamePropertyName();
    }
}