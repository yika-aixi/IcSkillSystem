using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
//    [NodeEditor.CustomNodeEditorAttribute(typeof(RootNode))]
    public class RootNodeEditor:NodeEditor 
    {
        private RootNode rootNode;

        public override void OnBodyGUI() {
            if (rootNode == null) rootNode = target as RootNode;

            // Update serialized object's representation
            serializedObject.Update();

//            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("BlackBoard"));
//            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Clok"));
//            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("_rootOut"));
//            EditorGUILayout.BeginHorizontal();
//            {
//                EditorGUILayout.BeginHorizontal();
//                EditorGUILayout.EndHorizontal();
//                {
//                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("_mainNode"),new GUIContent("","Main Node"));
//                }
//                EditorGUILayout.BeginHorizontal();
//                EditorGUILayout.EndHorizontal();
//            }
//            EditorGUILayout.EndHorizontal();

            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }
    }
}