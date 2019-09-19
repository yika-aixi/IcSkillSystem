using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using UnityEditor;
using UnityEngine;
using XNodeEditor;
using EditorGUIUtility = UnityEditor.Experimental.Networking.PlayerConnection.EditorGUIUtility;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(RootNode))]
    public class RootNodeEditor:NodeEditor 
    {
        private RootNode rootNode;

        public override Color GetTint()
        {
            _check();
            
            if (rootNode.GetInputValue<NPBehaveNode>("_mainNode",null) == null)
            {
                return Color.red;
            }            
            
            return base.GetTint();
        }

        public override void OnBodyGUI()
        {
            // Update serialized object's representation
            serializedObject.Update();
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("_blackBoard"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("_clok"));
            EditorGUILayout.BeginHorizontal();
            {
                {
                    EditorGUILayout.LabelField(string.Empty,GUILayout.Width(GetWidth() / 2));
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("_mainNode"),new GUIContent("","Main Node"));
                }
            }
            EditorGUILayout.EndHorizontal();

            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }

        private void _check()
        {
            if (rootNode == null) rootNode = target as RootNode;
        }
    }
}