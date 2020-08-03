using System.Linq;
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
    [CustomNodeEditor(typeof(GetChildGraphNode))]
    public class GetChildGroupNodeEditor:NodeEditor 
    {
        private ChildGraphNode rootNode;

        private ReorderableList _dynamicOut;
        private ReorderableList _dynamicIn;

        public override void OnInit()
        {
            _updatePort();
            _lastWindow = NodeEditorWindow.current;
        }

        private IcSkillGraph _currentGraph;
        private SerializedProperty _groupSer;
        NodeEditorWindow _lastWindow;
        public override void OnBodyGUI()
        {
            if (_lastWindow != NodeEditorWindow.current)
            {
                _lastWindow = NodeEditorWindow.current;
                
                _updatePort();
            }
            serializedObject.Update();
            {
                EditorGUI.BeginChangeCheck();
                {
                    if (_groupSer == null)
                    {
                        _groupSer = serializedObject.FindProperty(GetChildGraphNode.GroupFieldName);
                    }

                    NodeEditorGUILayout.PropertyField(_groupSer,new GUIContent("Group"));
                    _currentGraph = (IcSkillGraph) _groupSer.objectReferenceValue;
                }
                if (EditorGUI.EndChangeCheck())
                {
                    _updatePort();
                }

                NodeEditorGUILayout.DynamicPortList("in", typeof(object), serializedObject, NodePort.IO.Input,
                    Node.ConnectionType.Override, onCreation: _listSettingInput);
                
                NodeEditorGUILayout.DynamicPortList("out", typeof(object), serializedObject, NodePort.IO.Output,
                    Node.ConnectionType.Multiple, onCreation: _listSettingOutput);
                
                NodeEditorGUILayout.PortField(new GUIContent("Group Root"),target.GetPort(nameof(GetChildGraphNode.OutValue)));
            }
            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }

        private void _updatePort()
        {
            if(_currentGraph == null)
                return;
            
            var groupPort = _getChildGroupNode(_currentGraph);

            if (groupPort)
            {
                var childGroupNodePort = groupPort.DynamicPorts.ToList();

                var thisPort = target.DynamicPorts.ToList();
                
                //remove 
                foreach (var port in thisPort)
                {
                    // continue OutValue
                    if (port.fieldName == nameof(GetChildGraphNode.OutValue))
                    {
                        continue;
                    }
                    
                    if (!childGroupNodePort.Exists(x => x.fieldName == port.fieldName))
                    {
                        target.RemoveDynamicPort(port);
                    }
                }

                //add
                foreach (var port in childGroupNodePort)
                {
                    // continue OutValue
                    if (port.fieldName == nameof(GetChildGraphNode.OutValue))
                    {
                        continue;
                    }
                    
                    if (!target.HasPort(port.fieldName))
                    {
                        if (port.direction == NodePort.IO.Input)
                        {
                            target.AddDynamicOutput(port.ValueType, Node.ConnectionType.Multiple, port.typeConstraint,
                                port.fieldName);
                        }
                        else
                        {
                            target.AddDynamicInput(port.ValueType, Node.ConnectionType.Override, Node.TypeConstraint.Inherited,port.fieldName);                              
                        }
                     

                        EditorUtility.SetDirty(target);
                        serializedObject.ApplyModifiedProperties();
                        serializedObject.Update();
                    }
                }
            }
        }

        ChildGraphNode _getChildGroupNode(IcSkillGraph skillGraph)
        {
            if (!skillGraph)
            {
                return null;
            }
            
            foreach (var node in skillGraph.nodes)
            {
                if (node is ChildGraphNode childGroupNode)
                {
                    return childGroupNode;
                }
            }

            return null;
        }

        private void _listSettingOutput(ReorderableList list)
        {
            _dynamicOut = list;
            //todo Because the submap will be used in multiple places, port add and delete actions are currently not given.
            _dynamicOut.displayAdd = false;
            _dynamicOut.displayRemove = false;
            
            _dynamicOut.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "Out Values");
            };
        }
        
        private void _listSettingInput(ReorderableList list)
        {
            _dynamicIn = list;
            //todo Because the submap will be used in multiple places, port add and delete actions are currently not given.
            _dynamicIn.displayAdd = false;
            _dynamicIn.displayRemove = false;
            
            _dynamicIn.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "Input Values");
            };
        }
    }
}