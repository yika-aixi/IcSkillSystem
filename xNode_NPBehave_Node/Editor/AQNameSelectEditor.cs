﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
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

        private bool _error;
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
                _error = true;
                Debug.LogError($"无法找到类型:{_aQNameProperty.stringValue}");
                return;
            }

            _error = false;
            
            var fields = type.GetFields();
            var properties = type.GetProperties();
            
            List<MemberInfo> memberInfos = new List<MemberInfo>();
            memberInfos.AddRange(fields);
            memberInfos.AddRange(properties);
            
            var inputs = new List<NodePort>();
            inputs.AddRange(dynamicPorts);
            
            _updateDynamicPort(inputs,memberInfos, x=>
            {
                if (x is FieldInfo fieldInfo)
                {
                    return fieldInfo.FieldType;
                }

                return ((PropertyInfo) x).PropertyType;
            });

            serializedObject.UpdateIfRequiredOrScript();
        }

        protected virtual IEnumerable<NodePort> GetDynamicPort()
        {
            return null;
        }

        public override Color GetTint()
        {
            if (_error)
            {
                return Color.red;
            }
            
            return base.GetTint();
        }

        #region 动态节点更新

        private void _updateDynamicPort(IEnumerable<NodePort> dynamicPort,IEnumerable<MemberInfo> memberInfos, Func<MemberInfo, Type> getType)
        {
            _removeNoExist(dynamicPort, memberInfos, getType);

            _addDynamicPort(dynamicPort, memberInfos, getType);
        }

        private void _addDynamicPort(IEnumerable<NodePort> dynamicPort, IEnumerable<MemberInfo> memberInfos, Func<MemberInfo, Type> getType)
        {
            //添加新的
            foreach (var info in memberInfos)
            {
                bool hit = false;
                foreach (var nodePort in dynamicPort)
                {
                    if (nodePort.ValueType == getType(info) && nodePort.fieldName == info.Name)
                    {
                        hit = true;
                        break;
                    }
                }

                if (!hit)
                {
                    TNode.AddDynamicInput(getType(info), Node.ConnectionType.Override, fieldName: info.Name,typeConstraint:Node.TypeConstraint.Inherited);
                }
            }
        }

        private void _removeNoExist(IEnumerable<NodePort> dynamicPort, IEnumerable<MemberInfo> memberInfos, Func<MemberInfo, Type> getType)
        {
            //删除被不存在的
            foreach (var nodePort in dynamicPort)
            {
                bool hit = false;
                foreach (var info in memberInfos)
                {
                    if (nodePort.ValueType == getType(info) && nodePort.fieldName == info.Name)
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