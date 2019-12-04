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
            Event e = Event.current;

            if (_editMode)
            {
                if (_editMode && (_lastIndex != index || _lastList != list) && isactive)
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
            }
            
            if (isactive)
            {
                if (e.type == EventType.MouseDown)
                {
                    if (e.button == 0)
                    {
                        if (e.clickCount >= 2 && !_editMode)
                        {
                            _setEdit(list,index);
                            e.Use();
                        }
                    }
                }
            }
            
            if (_editMode && isactive)
            {
                NodePort oldPort = ((NodePort) list.list[index]);
                GUI.SetNextControlName(index.ToString());
                EditorGUI.FocusTextInControl(index.ToString());

                string newName = oldPort.fieldName;
                EditorGUI.BeginChangeCheck();
                {
                    bool contains = false;
                    Rect lastRect;
                    try
                    {
                        newName = EditorGUI.DelayedTextField(rect, oldPort.fieldName);
                        lastRect = new Rect(GUILayoutUtility.GetLastRect());
                        var y = lastRect.yMax - list.GetHeight(); // ReorderableList start Y pos
                        y += 20; // add ReorderableList title pos
                        y += index * 20f;//add element y pos
                        lastRect.position = new Vector2(lastRect.position.x,y);
                        contains = lastRect.Contains(e.mousePosition);
                        if (e.type == EventType.MouseDown && !contains)
                        {
                            _clearEdit();
                            Event.current.Use();
                        }

                        if (e.type == EventType.Repaint && !contains)
                        {
                            _clearEdit();
                        }
                    }
                    catch (ArgumentException)
                    {
                        if (!contains)
                        {
                            _clearEdit();
                        }
                    }
                }
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
                        node.AddDynamicOutput(typeof(object), Node.ConnectionType.Multiple, fieldName: x);
                    });
                });
    
            NodeEditorGUILayout.DynamicPortList("in", typeof(object), serializedObject, NodePort.IO.Output,
                Node.ConnectionType.Multiple, onCreation: _outListSetting, onAdd:x =>
                {
                    _updateGetChildNodeGroup((group,node) =>
                    {
                        node.AddDynamicInput(typeof(object), Node.ConnectionType.Override,Node.TypeConstraint.Inherited, fieldName: x);
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

            _dynamicOut.drawElementCallback += (rect, index, active, focused) => _valueTypeSelect(list,rect,index,active,focused);
            
            _dynamicOut.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "Out Values");
            };

            _dynamicOut.onRemoveCallback += x =>
            {
                var port = (NodePort) x.list[x.index];
                
                _updateGetChildNodeGroup((group,node) =>
                {
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

           _dynamicIn.drawElementCallback += (rect, index, active, focused) => _synPortValueType(list,index);
           
            _dynamicIn.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "Input Values");
            };
            
            _dynamicIn.onRemoveCallback += x =>
            {
                var port = (NodePort) x.list[x.index];
                
                _updateGetChildNodeGroup((group,node) =>
                {
                    node.RemoveDynamicPort(port.fieldName);
                });
            };
        }

        private SimpleTypeSelectPopupWindow _typeSelectPopupWindow;
        private void _valueTypeSelect(ReorderableList list, Rect rect, int index, bool isActive, bool isFocused)
        {
            if (_typeSelectPopupWindow == null)
            {
                _typeSelectPopupWindow = new SimpleTypeSelectPopupWindow(true,TypeUtil.GetRuntimeTypes);
            }
            
            var newRect = new Rect(rect);

            newRect.position = new Vector2(GetWidth() - 40,newRect.position.y);
            
            newRect.size = new Vector2(18,18);
            
            if (GUI.Button(newRect,"T"))
            {
                _typeSelectPopupWindow.OnChangeTypeSelect = type =>
                {
                    _typeSelectPopupWindow.editorWindow.Close();
                    
                    NodePort port = (NodePort) list.list[index];

                    port.ValueType = type;
                
                    _updateGetChildNodeGroup((group, node) =>
                    {
                        var nodePort = node.GetPort(port.fieldName);
                    
                        nodePort.ValueType = type;
                    });
                };
                
                newRect = rect;
                
                newRect.position += new Vector2(0, 20);
                PopupWindow.Show(newRect, _typeSelectPopupWindow);
            }
        }

        private void _synPortValueType(ReorderableList list, int index)
        {
            NodePort port = (NodePort) list.list[index];

            if (port.IsConnected)
            {
                var type = port.GetConnection(0).ValueType;
                
                if (port.ValueType != type)
                {
                    port.ValueType = type;
                    _updateGetChildNodeGroup((group, node) => { node.GetPort(port.fieldName).ValueType = type; });
                }
            }
        }

        private void _check()
        {
            if (rootNode == null) rootNode = target as ChildGroupNode;
        }
    }
}