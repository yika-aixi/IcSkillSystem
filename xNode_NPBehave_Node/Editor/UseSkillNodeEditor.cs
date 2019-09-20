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
            _skillProperty.stringValue = _Types[_selectIndex];

            _skillNode.ClearDynamicPorts();

            Type type = Type.GetType(_Types[_selectIndex]);
            var fields = type.GetFields();

            foreach (var field in fields)
            {
                _skillNode.AddDynamicInput(field.FieldType, Node.ConnectionType.Override, fieldName: field.Name);
            }

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                _skillNode.AddDynamicInput(property.PropertyType, Node.ConnectionType.Override, fieldName: property.Name);
            }

            serializedObject.UpdateIfRequiredOrScript();
        }

        private void _baseDraw()
        {
            NodeEditorGUILayout.PropertyField(_blackboardProperty);
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("_skillNode"));
        }
    }
}