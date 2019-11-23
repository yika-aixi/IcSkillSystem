using CabinIcarus.IcSkillSystem.Runtime.Nodes;
using NPBehave;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(ChildGroupNode))]
    public class ChildGroupNodeEditor:NodeEditor 
    {
        private ChildGroupNode rootNode;

        public override Color GetTint()
        {
            _check();
            
            if (!rootNode.GetPort("_main").IsConnected)
            {
                return new Color(205 / 255f,20 / 255f,25 / 255f);
            }            
            
            return new Color(30 / 255f,147 / 255f,65 / 255f);
        }

        public override void OnBodyGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.BeginHorizontal();
            {
                {
                    EditorGUILayout.LabelField(string.Empty,GUILayout.Width(GetWidth() / 2));
                    NodeEditorGUILayout.PortField(new GUIContent("Main Node"),target.GetPort("_main"));
                }
            }
            EditorGUILayout.EndHorizontal();

            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }

        private void _check()
        {
            if (rootNode == null) rootNode = target as ChildGroupNode;
        }
    }
}