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
                if (type != typeof(RootNode) && type != typeof(ChildGroupNode))
                {
                    return true;
                }

                var result = group.nodes.Any(x => x is RootNode || x is ChildGroupNode);
 
                return !result;
            };
        }

        public override void OnBodyGUI()
        {
            serializedObject.Update();
            
            NodeEditorGUILayout.PortField(new GUIContent("Blackboard"),target.GetPort("_blackBoard"));
            NodeEditorGUILayout.PortField(new GUIContent("Clock"),target.GetPort("_clok"));
            
            EditorGUILayout.BeginHorizontal();
            {
                {
                    EditorGUILayout.LabelField(string.Empty,GUILayout.Width(GetWidth() / 2));
                    NodeEditorGUILayout.PortField(new GUIContent("Main Node"),target.GetPort("_mainNode"));
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