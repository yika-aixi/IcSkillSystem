//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月20日-00:17
//Assembly-CSharp-Editor

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(UseSkillNode))]
    public class UseSkillNodeEditor:AQNameSelectEditor<UseSkillNode>
    {
        protected override Type GetBaseType()
        {
            return typeof(ISkillDataComponent);
        }

        protected override string GetAQNamePropertyName()
        {
            return "_skillComponentAQName";
        }

        protected override IEnumerable<NodePort> GetDynamicPort()
        {
            return TNode.DynamicInputs;
        }

        private SerializedProperty _getBlackboardValueProperty;
        private SerializedProperty _outputProperty;
        protected override void DrawBody()
        {
            base.DrawBody();
            serializedObject.Update();

            DrawSelectPop(new GUIContent("Skill: "));
            
            EditorGUILayout.Space();
            {
                var lastRect = GUILayoutUtility.GetLastRect();
                var lineX = GetWidth() * 0.9f;
                var lineY = lastRect.y + 5;
                var offset = GetWidth() - lineX;
                Handles.DrawLine(new Vector3(offset, lineY), new Vector3(lineX, lineY));
            }
            EditorGUILayout.Space();

            DrawDynamicPort(null);
            
            serializedObject.ApplyModifiedProperties();
        }

    }
}