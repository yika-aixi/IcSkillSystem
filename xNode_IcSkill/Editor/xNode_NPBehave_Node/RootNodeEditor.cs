using System.Linq;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.xNode_Group.Editor;
using NPBehave;
using UnityEditor;
using UnityEngine;
using XNodeEditor;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    [CustomNodeEditor(typeof(RootNode))]
    public class RootNodeEditor: ANPBehaveNodeEditor<RootNode,Root>
    {
        private RootNode rootNode;
        private SerializedProperty _autoStartSer;
        private SerializedProperty _prioritySer;

        protected override void ColorCheck()
        {
            _check();

            base.ColorCheck();
        }

        protected override void Init()
        {
            _stor();
            
            IcSkillGroupEditor.OnAllowCreate += (group,type) =>
            {
                if (type != typeof(RootNode))
                {
                    return true;
                }

                var result = group.nodes.Any(x => x is ChildGraphNode);
 
                return !result;
            };
        }

        protected override void DrawBody()
        {
            serializedObject.Update();
            {
                EditorGUI.BeginChangeCheck();
                {
                    if (_prioritySer == null)
                    {
                        _prioritySer = serializedObject.FindProperty(nameof(RootNode.Priority));
                    }

                    EditorGUILayout.DelayedIntField(_prioritySer,new GUIContent("Priority",""));
                }
                if (EditorGUI.EndChangeCheck())
                {
                    serializedObject.ApplyModifiedProperties();
                    _stor();
                    serializedObject.ApplyModifiedProperties();
                    EditorUtility.SetDirty(target.graph);
                }

                if (_autoStartSer == null)
                {
                    _autoStartSer = serializedObject.FindProperty(nameof(RootNode.AutoStart));
                }

                var isFirstRoot = rootNode.graph.nodes[rootNode.graph.nodes.Count-1] == rootNode;
                GUI.enabled = !isFirstRoot;
                {
                    _autoStartSer.boolValue = EditorGUILayout.ToggleLeft(new GUIContent("Group Start Auto Start",isFirstRoot ? "First Root Node Must be auto Start":""),
                        _autoStartSer.boolValue);

                    if (isFirstRoot)
                    {
                        rootNode.AutoStart = true;
                    }
                }
                GUI.enabled = true;

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

        private void _stor()
        {
            target.graph.nodes.Sort((a, b) =>
            {
                if (a is RootNode aRoot
                    && b is RootNode bRoot)
                {
                    return -aRoot.Priority.CompareTo(bRoot.Priority);
                }
            
                if (a is RootNode)
                {
                    return 1;
                }
            
                if (b is RootNode)
                {
                    return -1;
                }
            
                return -1;
            });
        }

        private void _check()
        {
            if (rootNode == null) rootNode = target as RootNode;
        }
    }
}