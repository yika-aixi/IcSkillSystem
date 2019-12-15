using System.Linq;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.xNode_Group.Editor;
using NPBehave;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    [CustomNodeEditor(typeof(RootNode))]
    public class RootNodeEditor:NodeEditor 
    {
        private RootNode rootNode;

        public override Color GetTint()
        {
            _check();
            
            if (!rootNode.GetPort("_mainNode").IsConnected)
            {
                return new Color(205 / 255f,20 / 255f,25 / 255f);
            }            
            
            return new Color(30 / 255f,147 / 255f,65 / 255f);
        }

        public override void OnInit()
        {
            IcSkillGroupEditor.OnAllowCreate += (group,type) =>
            {
                if (type != typeof(RootNode))
                {
                    return true;
                }

                var result = group.nodes.Any(x => x is ChildGroupNode);
 
                return !result;
            };
        }

        public override void OnHeaderGUI()
        {
            base.OnHeaderGUI();

            var rect = GUILayoutUtility.GetLastRect();

            rect.position = new Vector2(this.GetWidth() - 40,rect.position.y + 5);
            
            rect.size = new Vector2(30,16);

            EditorGUI.PropertyField(rect,serializedObject.FindProperty(nameof(RootNode.Priority)),new GUIContent(""));
        }

        public override void OnBodyGUI()
        {
            serializedObject.Update();
            {
                NodeEditorGUILayout.PortField(new GUIContent("Blackboard"), target.GetPort("_blackBoard"));
                NodeEditorGUILayout.PortField(new GUIContent("Clock"), target.GetPort("_clok"));
                NodeEditorGUILayout.PortField(new GUIContent("Root"), target.GetPort(nameof(RootNode.OutValue)));

                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(string.Empty, GUILayout.Width(GetWidth() / 3.5f));

                    EditorGUILayout.BeginVertical();
                    {
                        EditorGUILayout.LabelField(new GUIContent("Main Node"));
                        EditorGUILayout.BeginHorizontal();
                        {
                            #region Spaces

                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();

                            #endregion
                            
                            NodeEditorGUILayout.PortField(new GUIContent(""), target.GetPort("_mainNode"));
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndHorizontal();
                
            }
            serializedObject.ApplyModifiedProperties();
        }

        private void _check()
        {
            if (rootNode == null) rootNode = target as RootNode;
        }
    }
}