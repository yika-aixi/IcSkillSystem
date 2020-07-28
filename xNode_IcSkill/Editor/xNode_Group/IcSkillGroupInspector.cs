using System;
using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.Editor;
using CabinIcarus.IcSkillSystem.Editor.Utils;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using XNode;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    [CustomEditor(typeof(IcSkillGraph))]
    public class IcSkillGroupInspector : UnityEditor.Editor
    {
        private IcSkillGraph _graph;

        private static Type[] _types;

        private static ValueEditPopupWindow _ValueEditPopup;
        private static SimpleTypeSelectPopupWindow _simpleTypeSelect;
        private Rect _rect;
        private SerializedProperty _varMapSer;
        private void OnEnable()
        {
            if (_types == null)
            {
                _types = TypeUtil.GetRuntimeFilterTypes.ToArray();                
                _ValueEditPopup = new ValueEditPopupWindow();
                _ValueEditPopup.OnEdit = _save;
                _simpleTypeSelect = new SimpleTypeSelectPopupWindow(true,_types);
            }
            
            _varMapSer = serializedObject.FindProperty(IcSkillGraph.VarMapFieldName);
            
            _graph = (IcSkillGraph) target;
        }

        void _save()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorUtility.SetDirty(target);
        }

        public override void OnInspectorGUI()
        {
            if (EditorWindow.mouseOverWindow)
            {
                _rect = EditorWindow.mouseOverWindow.position;
            }

            serializedObject.Update();
            {
                _drawNodes();
                _drawBlackboardVar();
            }
            serializedObject.ApplyModifiedProperties();
        }

        #region Nodes

        private SerializedProperty _nodesSer;
        private SerializedProperty _portsSer;
        private bool _showNodes;
        Dictionary<int,bool> _nodeStateMap = new Dictionary<int, bool>();
        Dictionary<int,ReorderableList> _connectionsMap = new Dictionary<int, ReorderableList>();
        private Object _lastTarget;
        
        private void _drawNodes()
        {
            if (_nodesSer == null)
            {
                _nodesSer = serializedObject.FindProperty("nodes");
            }

            if (_lastTarget != target)
            {
                _nodeStateMap.Clear();
                _connectionsMap.Clear();
                _lastTarget = target;
            }

            _showNodes = EditorGUILayout.Foldout(_showNodes, "Nodes", true);

            if (!_showNodes)
            {
                return;
            }
            EditorGUI.indentLevel++;
            {
                for (var i = 0; i < _nodesSer.arraySize; i++)
                {
                    if (!_nodeStateMap.ContainsKey(i))
                    {
                        _nodeStateMap.Add(i, false);
                        _connectionsMap.Add(i,null);
                    }

                    var node = _nodesSer.GetArrayElementAtIndex(i);

                    _nodeStateMap[i] = EditorGUILayout.Foldout(_nodeStateMap[i], node.objectReferenceValue?.name ?? "Missing", true);

                    if (_nodeStateMap[i])
                    {
                        var nodeO = new SerializedObject(node.objectReferenceValue);
                        SerializedProperty portsSer = nodeO.FindProperty("ports");
                        SerializedProperty valuesSer = portsSer.FindPropertyRelative("values");
                        
                        for (var j = 0; j < valuesSer.arraySize; j++)
                        {
                            var property = valuesSer.GetArrayElementAtIndex(j);

                            var connections = property.FindPropertyRelative("connections");
                            
                            if (property.FindPropertyRelative("_direction").enumValueIndex == (int) NodePort.IO.Input)
                            {
                                EditorGUI.indentLevel++;
                                {
                                    if (connections.arraySize > 1)
                                    {
                                        ReorderableList list = _connectionsMap[i];
                                        if (list == null)
                                        {
                                            list = new ReorderableList(nodeO, connections, true, true, 
                                                false, false);
                                            list.drawHeaderCallback = rect => EditorGUI.LabelField(rect,"Input");
                                            list.drawElementCallback = (rect, index, active, focused) =>
                                            {
                                                var output = connections.GetArrayElementAtIndex(index);
                                                var targetNode = output.FindPropertyRelative("node");
                                                try
                                                {
                                                    EditorGUI.LabelField(rect, $"{index + 1} : {targetNode.objectReferenceValue.name}");
                                                    var removeButtonRect = rect;

                                                    removeButtonRect.size = new Vector2(30,rect.height);
                                                    removeButtonRect.position = new Vector2(rect.width - 10,removeButtonRect.position.y);
                                                
                                                    if (GUI.Button(removeButtonRect,EditorGUIUtility.FindTexture("d_P4_DeletedLocal")))
                                                    {
                                                        _graph.RemoveNode((Node) targetNode.objectReferenceValue);
                                                    }
                                                }
                                                catch (Exception)
                                                {
                                                    EditorGUI.LabelField(rect, $"{index + 1} Missing");
                                                }
                                            };
                                            list.onReorderCallback = _ =>
                                            {
                                                _save();
                                            }; 
                                            _connectionsMap[i] = list;
                                        }
                                        
                                        EditorGUI.indentLevel-=2;
                                        {
                                            list.DoLayoutList();
                                        }
                                        EditorGUI.indentLevel+=2;
                                    }
                                    else
                                    {
                                        if (connections.arraySize > 0)
                                        {
                                            var output = connections.GetArrayElementAtIndex(0);
                                            var targetNode = output.FindPropertyRelative("node");
                                            EditorGUILayout.LabelField(targetNode.objectReferenceValue.name);
                                        }
                                        else
                                        {
                                            EditorGUILayout.HelpBox("No Connection",MessageType.Info);
                                        }

                                        
                                    }
                                }
                                EditorGUI.indentLevel--;
                            }
                            else
                            {
                                EditorGUILayout.LabelField("OutPut");
                                EditorGUI.indentLevel++;
                                {
                                    if (connections.arraySize > 0)
                                    {
                                        var output = connections.GetArrayElementAtIndex(0);
                                        var targetNode = output.FindPropertyRelative("node");
                                        EditorGUILayout.LabelField(targetNode.objectReferenceValue.name);
                                    }
                                }
                                EditorGUI.indentLevel--;
                            }
                        }
                    }
                }
            }
            EditorGUI.indentLevel--;
        }

        #endregion

        #region BloackBoard Variable

        private bool _showBlackboard;
        private ReorderableList list1;

        private void _drawBlackboardVar()
        {
            _showBlackboard = EditorGUILayout.Foldout(_showBlackboard, "Blackboard Variable",true);

            if (!_showBlackboard)
            {
                return;
            }

            EditorGUILayout.PropertyField(_varMapSer);
        }

        #endregion
    }
}