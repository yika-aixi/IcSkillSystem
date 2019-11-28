using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.xNode_Group.Editor;
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

        protected override void Init()
        {
            base.Init();

            IcSkillGroupEditor.OnAllowCreate += type =>
            {
                if (type != typeof(RootNode) && type != typeof(ChildGroupNode))
                {
                    return true;
                }
                
                foreach (var node in target.graph.nodes)
                {
                    if (node is  RootNode && type == typeof(RootNode) ||
                        node is  ChildGroupNode && type == typeof(ChildGroupNode))
                    {
                        return false;
                    }
                }

                return true;
            };
        }

        public static event Action<ChildGroupNode,string> OnAddPort;
        public static event Action<ChildGroupNode,string> OnRemovePort;
        /// <summary>
        /// arg 1: index
        /// arg 2: Port old Name;
        /// arg 3: Port new Name;
        /// </summary>
        public static event Action<ChildGroupNode,int,string,string> OnRename;
        
        private ReorderableList _dynamicIn;
        private ReorderableList _dynamicOut;
        private double _lastTime;
        private ReorderableList _lastList;
        private int _lastIndex;
        private int _clickCount;
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
                _lastTime = -1;
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
//                        Debug.LogError($"{_clickCount} == {EditorApplication.timeSinceStartup - _lastTime}");
                        if (EditorApplication.timeSinceStartup - _lastTime > 1f)
                        {
                            _clickCount = 0;
                        }

                        _lastTime = EditorApplication.timeSinceStartup;
                        _clickCount++;

                        if (_clickCount >= 2)
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
                
                EditorGUI.BeginChangeCheck();
                    var newName = EditorGUI.DelayedTextField(rect, oldPort.fieldName);
                if (EditorGUI.EndChangeCheck())
                {
                    _clearEdit();
                    
                    var port = target.AddDynamicInput(typeof(object), fieldName: newName);

                    port.AddConnections(oldPort);

                    target.RemoveDynamicPort(oldPort);

                    OnRename?.Invoke((ChildGroupNode) target,index, oldPort.fieldName,newName);
                }
            }
        }

        public override void OnBodyGUI()
        {
            serializedObject.Update();

            NodeEditorGUILayout.DynamicPortList("out",typeof(object),serializedObject,NodePort.IO.Input,
                Node.ConnectionType.Override,onCreation:_inListSetting,onAdd: name =>
                {
                    OnAddPort?.Invoke((ChildGroupNode) target, name);
                });
        
            NodeEditorGUILayout.DynamicPortList("in", typeof(object), serializedObject, NodePort.IO.Output,
                Node.ConnectionType.Multiple, onCreation: _outListSetting);
            
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

            _dynamicOut.onRemoveCallback += x =>
            {
                OnRemovePort?.Invoke((ChildGroupNode) target, ((NodePort)x.list[x.index]).fieldName);
            };
            
            _dynamicOut.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "Out Values");
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

           _dynamicIn.onRemoveCallback += x =>
           {
               OnRemovePort?.Invoke((ChildGroupNode) target, ((NodePort)x.list[x.index]).fieldName);
           };
            
            _dynamicIn.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "Input Values");
            };
        }

        private void _check()
        {
            if (rootNode == null) rootNode = target as ChildGroupNode;
        }
    }
}