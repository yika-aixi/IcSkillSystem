using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Boo.Lang;
using CabinIcarus.IcSkillSystem.Runtime.Nodes;
using NPBehave;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using XNode;
using XNodeEditor;
using Node = XNode.Node;

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

        private ReorderableList _dynamicIn;

        private double _lastTime;
        private int _lastIndex;
        private int _clickCount;
        private bool _editMode;

        void _setEdit(int index)
        {
            _dynamicIn.index = index;
            _editMode = true;
        }

        void _clearEdit()
        {
            _editMode = false;
            _lastIndex = -1;
        }
        
        private void DrawElementCallback(Rect rect, int index, bool isactive, bool isfocused)
        {
            if (_lastIndex != index && isactive)
            {
                _clearEdit();
                _lastIndex = index;
            }

            if (isactive)
            {
                Event e = Event.current;

                if (e.type == EventType.KeyDown)
                {
                    if (e.keyCode == KeyCode.Escape)
                    {
                        _dynamicIn.ReleaseKeyboardFocus();
                        _clearEdit();
                        e.Use();
                        return;
                    }
                }
                
                if (e.type == EventType.MouseDown || 
                    !_editMode && e.type == EventType.KeyDown && _dynamicIn.index == index)
                {
                    if (e.button == 0 || e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter)
                    {
                        if (EditorApplication.timeSinceStartup - _lastTime > 0.5f)
                        {
                            _clickCount = 0;
                        }

                        _lastTime = EditorApplication.timeSinceStartup;
                        _clickCount++;

                        if (_clickCount >= 2)
                        {
                            _setEdit(index);
                            e.Use();
                        }
                    }
                }
            }
            
            NodePort oldPort = ((NodePort) _dynamicIn.list[index]);
            
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

                    _dynamicIn.list.Add(port);
                    _dynamicIn.list.Remove(oldPort);
                }
            }
        }

        public override void OnBodyGUI()
        {
            serializedObject.Update();
            
            NodeEditorGUILayout.DynamicPortList("arg",typeof(object),serializedObject,NodePort.IO.Input,Node.ConnectionType.Override,onCreation:_listSetting);
            
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField(string.Empty,GUILayout.Width(GetWidth() / 2));
                NodeEditorGUILayout.PortField(new GUIContent("Main Node"),target.GetPort("_main"));
            }
            EditorGUILayout.EndHorizontal();

            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }

        private void _listSetting(ReorderableList list)
        {
            _dynamicIn = list;
            
            _dynamicIn.onAddCallback += x =>
            {
                _setEdit(list.index);
            };

           _dynamicIn.drawElementCallback += DrawElementCallback;
            
            _dynamicIn.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "Out Values");
            };
        }

        private void _check()
        {
            if (rootNode == null) rootNode = target as ChildGroupNode;
        }
    }
}