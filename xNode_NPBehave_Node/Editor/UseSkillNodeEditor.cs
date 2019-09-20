//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月20日-00:17
//Assembly-CSharp-Editor

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Task;
using DesperateDevs.Utils;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(UseSkillNode))]
    public class UseSkillNodeEditor:NodeEditor
    {
        private static List<string> _Types;
        private UseSkillNode _skillNode;

        public override void OnCreate()
        {
            _skillNode = (UseSkillNode) target;
            _skillProperty = serializedObject.FindProperty("_skillComponentAQName");
            _blackboardProperty = serializedObject.FindProperty("_blackboardNode");
            _Types = new List<string>();

#if IcEditorFrame
            _Types.AddRange(CabinIcarus.EditorFrame.Utils.TypeUtil.GetFilterSystemAssemblyQualifiedNames(typeof(ISkillDataComponent)));
#else
            _Types.AddRange(AppDomain.CurrentDomain.GetAllTypes().Where(x=> typeof(ISkillDataComponent).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(x=>x.AssemblyQualifiedName));
#endif

            _selectIndex = _Types.FindIndex(x=> x == _skillProperty.stringValue);
            
            //刷新一下动态Port
            _dynamicPort();
        }


        private int _selectIndex;
        private SerializedProperty _skillProperty;
        private SerializedProperty _blackboardProperty;

        public override void OnBodyGUI()
        {
            serializedObject.Update();

            _baseDraw();
            
            _selectIndex = EditorGUILayout.Popup("Skill: ", _selectIndex,_Types.Select(x=>x.Split(',')[0]).ToArray());

            if (GUI.changed)
            {
                _skillProperty.stringValue = _Types[_selectIndex];
                _dynamicPort();
            }
            
            EditorGUILayout.Space();
            {
                var lastRect = GUILayoutUtility.GetLastRect();
                var lineX = GetWidth() * 0.9f;
                var lineY = lastRect.y + 5;
                var offset = GetWidth() - lineX;
                Handles.DrawLine(new Vector3(offset, lineY), new Vector3(lineX, lineY));
            }
            EditorGUILayout.Space();

            foreach (var nodePort in _skillNode.DynamicInputs)
            {
                NodeEditorGUILayout.PortField(nodePort);
            }
            
            serializedObject.ApplyModifiedProperties();
        }

        private void _dynamicPort()
        {
            if (string.IsNullOrWhiteSpace(_skillProperty.stringValue))
            {
                return;
            }

            Type type = Type.GetType(_skillProperty.stringValue);
            
            var fields = type.GetFields();
            var properties = type.GetProperties();
            
            List<MemberInfo> memberInfos = new List<MemberInfo>();
            memberInfos.AddRange(fields);
            memberInfos.AddRange(properties);
            
            _updateDynamicPort(memberInfos, x=>
            {
                if (x is FieldInfo fieldInfo)
                {
                    return fieldInfo.FieldType;
                }

                return ((PropertyInfo) x).PropertyType;
            });

            serializedObject.UpdateIfRequiredOrScript();
        }

        private void _updateDynamicPort(IEnumerable<MemberInfo> memberInfos, Func<MemberInfo, Type> getType)
        {
            var inputs = new List<NodePort>();
            inputs.AddRange(_skillNode.DynamicInputs);
            //删除被不存在的
            foreach (var nodePort in inputs)
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
                    _skillNode.RemoveDynamicPort(nodePort);
                }
            }
            
            //添加新的
            foreach (var info in memberInfos)
            {
                bool hit = false;
                foreach (var nodePort in inputs)
                {
                    if (nodePort.ValueType == getType(info) && nodePort.fieldName == info.Name)
                    {
                        hit = true;
                        break;
                    }
                }
                if (!hit)
                {
                    _skillNode.AddDynamicInput(getType(info), Node.ConnectionType.Override, fieldName: info.Name);
                }
            }
        }

        private void _baseDraw()
        {
            NodeEditorGUILayout.PropertyField(_blackboardProperty);
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("_skillNode"));
        }
    }
}