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
    public class RootNodeEditor: ANPBehaveNodeEditor<RootNode,Root>
    {
        private RootNode rootNode;
        private SerializedProperty _autoStartSer;
        private SerializedProperty _prioritySer;
//
//        public override Color GetTint()
//        {
//            _check();
//            
//            if (!rootNode.GetPort("_mainNode").IsConnected)
//            {
//                return new Color(205 / 255f,20 / 255f,25 / 255f);
//            }            
//            
//            return new Color(30 / 255f,147 / 255f,65 / 255f);
//        }

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

                var result = group.nodes.Any(x => x is ChildGroupNode);
 
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
                }

                if (_autoStartSer == null)
                {
                    _autoStartSer = serializedObject.FindProperty(nameof(RootNode.AutoStart));
                }

                var isFirstRoot = rootNode.graph.nodes[0] == rootNode;
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
                    if (aRoot.Priority < bRoot.Priority)
                    {
                        return -1;
                    }
                        
                    if (aRoot.Priority > bRoot.Priority)
                    {
                        return 1;
                    }
                }
                else
                {
                    if (a is RootNode)
                    {
                        return -1;
                    }

                    if (b is RootNode)
                    {
                        return 1;
                    } 
                }
                    
                return 0;
            });
        }

        private void _check()
        {
            if (rootNode == null) rootNode = target as RootNode;
        }
    }
}