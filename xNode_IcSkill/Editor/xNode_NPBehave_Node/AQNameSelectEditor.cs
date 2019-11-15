using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using SkillSystem.xNode_NPBehave_Node.Utils;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
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
        protected List<string> Types;
        protected int CurrentSelectIndex;

        protected override IEnumerable<string> GetExcludesField()
        {
            var AQName = GetAQNamePropertyName();

            if (string.IsNullOrWhiteSpace(AQName))
            {
                return null;
            }
            
            return new[] {AQName};
        }

        protected override void OnInit()
        {
            Types = new List<string>();
            _aQNameProperty = serializedObject.FindProperty(GetAQNamePropertyName());

            if (_aQNameProperty == null)
            {
                throw new NullReferenceException($"没有找到名为:'{GetAQNamePropertyName()}'的属性");
            }
            
#if IcEditorFrame
            Types.AddRange(CabinIcarus.EditorFrame.Utils.TypeUtil.GetFilterSystemAssemblyQualifiedNames(GetBaseType()));
#else
            Types.AddRange(AppDomain.CurrentDomain.GetAllTypes().Where(x=> GetBaseType().IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(x=>x.AssemblyQualifiedName));
#endif
            CurrentSelectIndex = Types.FindIndex(x=> x == _aQNameProperty.stringValue);
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
            CurrentSelectIndex = EditorGUILayout.Popup(title, CurrentSelectIndex,
                Types.Select(x=>x.Split(',')[0].Split('.').Last()).ToArray(),options);

            if (GUI.changed)
            {
                _aQNameProperty.stringValue = Types[CurrentSelectIndex];
                serializedObject.ApplyModifiedProperties();
                UpdateDynamicPort();
            }
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
            var defaultCtor =  type.GetConstructors()[0];
            var args = defaultCtor.GetParameters();
            List<TypeInfo> memberInfos = new List<TypeInfo>();
            memberInfos.AddRange(args.Select(x=> new TypeInfo(_getParameterName(x.Name),x.ParameterType)));
            memberInfos.AddRange(fields.Select(x=> new TypeInfo(x.Name,x.FieldType)));
            memberInfos.AddRange(properties.Where(x=>x.CanWrite).Select(x=> new TypeInfo(x.Name,x.PropertyType)));
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
                var defaultCtor =  type.GetConstructors()[0];
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