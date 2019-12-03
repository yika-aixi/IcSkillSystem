using System;
using CabinIcarus.IcSkillSystem.Nodes.Editor.Utils;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using XNode;
using XNodeEditor;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    [CustomNodeEditor(typeof(ChildGroupNode))]
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

        private ReorderableList _dynamicIn;
        private ReorderableList _dynamicOut;
        private ReorderableList _lastList;
        private int _lastIndex;
        private bool _editMode;

        void _setEdit(ReorderableList list,int index)
        {
            list.index = index;
            _editMode = true;
        }

        void _clearEdit()
        {
            _editMode = false;
            _lastIndex = -1;
            _lastList = null;
        }

        private void DrawElementCallback(ReorderableList list,Rect rect, int index, bool isactive, bool isfocused)
        {
            if ((_lastIndex != index || _lastList != list) && isactive)
            {
                if (_lastList != null)
                {
                    _lastList.ReleaseKeyboardFocus();
                    _lastList.index = -1;
                }
                
                _clearEdit();
                _lastIndex = index;
                _lastList = list;
            }
            
            Event e = Event.current;
            
            if (e.type == EventType.KeyDown)
            {
                if (e.keyCode == KeyCode.Escape)
                {
                    list.ReleaseKeyboardFocus();
                    _clearEdit();
                    e.Use();
                    return;
                }
            }
            
            if (isactive)
            {
                if (e.type == EventType.MouseDown)
                {
                    if (e.button == 0)
                    {
                        if (e.clickCount >= 2)
                        {
                            _setEdit(list,index);
                            e.Use();
                        }
                    }
                }
            }

            NodePort oldPort = ((NodePort) list.list[index]);
            
            if (_editMode && isactive)
            {
                GUI.SetNextControlName(index.ToString());
                EditorGUI.FocusTextInControl(index.ToString());
                
                Debug.LogError(GUILayoutUtility.GetLastRect ().Contains (e.mousePosition));
                if (e.type == EventType.MouseDown && !GUILayoutUtility.GetLastRect ().Contains (e.mousePosition))
                {
                    Debug.LogError("释放");
                    _clearEdit();
                    Event.current.Use();
                }
                
                EditorGUI.BeginChangeCheck();
                    var newName = EditorGUI.DelayedTextField(rect, oldPort.fieldName);
                if (EditorGUI.EndChangeCheck())
                {
                    _clearEdit();
                    
                    target.PortRename(oldPort,newName);
                    
                    //update all use this group of graph GetChildGroup Node
                    _updateGetChildNodeGroup((group,node) =>
                    {
                        node.PortRename(node.GetPort(oldPort.fieldName),newName);
                    });
                }
            }
        }

        void _updateGetChildNodeGroup(Action<IcSkillGroup,Node> onAction)
        {
            string[] guids = AssetDatabase.FindAssets ("t:" + typeof(IcSkillGroup));
                    
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);

                var group = AssetDatabase.LoadAssetAtPath<IcSkillGroup>(path);
                        
                foreach (var node in @group.nodes)
                {
                    if (node is GetChildGroupNode)
                    {
                        onAction?.Invoke(group,node);
                    }
                }
            }
        }

        public override void OnBodyGUI()
        {
            serializedObject.Update();

            NodeEditorGUILayout.DynamicPortList("out",typeof(object),serializedObject,NodePort.IO.Input,
                Node.ConnectionType.Override,onCreation:_inListSetting,onAdd: x =>
                {
                    _updateGetChildNodeGroup((group,node) =>
                    {
                        Debug.LogError($"{group.name} Add output port : {x}");
                        
                        node.AddDynamicOutput(typeof(object), Node.ConnectionType.Multiple, fieldName: x);
                    });
                });
        
            NodeEditorGUILayout.DynamicPortList("in", typeof(object), serializedObject, NodePort.IO.Output,
                Node.ConnectionType.Multiple, onCreation: _outListSetting, onAdd:x =>
                {
                    _updateGetChildNodeGroup((group,node) =>
                    {
                        Debug.LogError($"{group.name} Add Input port : {x} ");
                        
                        node.AddDynamicInput(typeof(object), Node.ConnectionType.Override, fieldName: x);
                    });
                });
            
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField(string.Empty,GUILayout.Width(GetWidth() / 2));
                NodeEditorGUILayout.PortField(new GUIContent("Main Node"),target.GetPort(ChildGroupNode.MainNodeFieldName));
            }
            EditorGUILayout.EndHorizontal();

            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }

        private void _outListSetting(ReorderableList list)
        {
            _dynamicOut = list;
            
            _dynamicOut.onAddCallback += x =>
            {
                var index = _dynamicOut.list.Count;
                
                _setEdit(list,index);
            };
 
            _dynamicOut.drawElementCallback += (rect, index, active, focused) => DrawElementCallback(list, rect, index, active, focused);

            _dynamicOut.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "Out Values");
            };

            _dynamicOut.onRemoveCallback += x =>
            {
                var port = (NodePort) x.list[x.index];
                
                _updateGetChildNodeGroup((group,node) =>
                {
                    Debug.LogError($"{group.name} Remove Output port : {port.fieldName} ");
                        
                    node.RemoveDynamicPort(port.fieldName);
                });
            };
        }
        
        private void _inListSetting(ReorderableList list)
        {
            _dynamicIn = list;

            _dynamicIn.onAddCallback += x =>
            {
                var index = _dynamicIn.list.Count;
                _setEdit(list,index);
            };
 
           _dynamicIn.drawElementCallback += (rect, index, active, focused) => DrawElementCallback(list, rect, index, active, focused);

            _dynamicIn.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "Input Values");
            };
            
            _dynamicIn.onRemoveCallback += x =>
            {
                var port = (NodePort) x.list[x.index];
                
                _updateGetChildNodeGroup((group,node) =>
                {
                    Debug.LogError($"{group.name} Remove Input port : {port.fieldName} ");
                        
                    node.RemoveDynamicPort(port.fieldName);
                });
            };
        }

        private void _check()
        {
            if (rootNode == null) rootNode = target as ChildGroupNode;
        }
    }
}