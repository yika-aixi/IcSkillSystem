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
    [CustomNodeEditor(typeof(GetChildGroupNode))]
    public class GetChildGroupNodeEditor:NodeEditor 
    {
        private ChildGroupNode rootNode;

        private ReorderableList _dynamicOut;

        private double _lastTime;
        private int _lastIndex;
        private int _clickCount;
        private bool _editMode;

        void _setEdit(int index)
        {
            _dynamicOut.index = index;
            _editMode = true;
        }

        private IcSkillGroup _childGroup => ((GetChildGroupNode)target).GetGroup();
        
        protected override void Init()
        {
            _updatePort();
//            ChildGroupNodeEditor.OnAddPort += _addPort;

            ChildGroupNodeEditor.OnRemovePort += _removePort;
            
            ChildGroupNodeEditor.OnRename += _rename;
        }

        private void _rename(ChildGroupNode node,int index, string oldName, string newName)
        {
            if (node.graph != _childGroup)
            {
                return;
            }
            
            NodePort oldPort = ((NodePort) _dynamicOut.list[index]);
            
            var port = target.AddDynamicOutput(typeof(object), fieldName: newName);

            port.AddConnections(oldPort);

            target.RemoveDynamicPort(oldPort);
        }

        private void _removePort(ChildGroupNode node, string name)
        {
            string[] guids = AssetDatabase.FindAssets ("t:" + typeof(IcSkillGroup));
            
            if (node.graph != _childGroup)
            {
                return;
            }
            
            target.RemoveDynamicPort(name);
        }

        private void _addPort(ChildGroupNode node, string name)
        {
            if (node.graph != _childGroup)
            {
                return;
            }

            target.AddDynamicOutput(typeof(object), fieldName: name);
        }

        private IcSkillGroup _currentGroup;
        private SerializedProperty _groupSer;
        public override void OnBodyGUI()
        {
            serializedObject.Update();
            {
                EditorGUI.BeginChangeCheck();
                {
                    if (_groupSer == null)
                    {
                        _groupSer = serializedObject.FindProperty(GetChildGroupNode.GroupFieldName);
                    }

                    NodeEditorGUILayout.PropertyField(_groupSer,new GUIContent("Group"));
                    _currentGroup = (IcSkillGroup) _groupSer.objectReferenceValue;
                }
                if (EditorGUI.EndChangeCheck())
                {
                    _updatePort();
                }

                NodeEditorGUILayout.DynamicPortList("", typeof(object), serializedObject, NodePort.IO.Output,
                    Node.ConnectionType.Override, onCreation: _listSetting);
                
                NodeEditorGUILayout.PortField(new GUIContent("Group Root"),target.GetPort(nameof(GetChildGroupNode.OutValue)));
            }
            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }

        private void _updatePort()
        {
            if(_currentGroup == null)
                return;
            
            var groupPort = _getChildGroupNode(_currentGroup);

            if (groupPort)
            {
                var childGroupNodePort = groupPort.DynamicInputs.ToList();

                //todo switch Child Group need refresh port
                var thisPort = target.DynamicOutputs.ToList();

                //remove 
                foreach (var port in thisPort)
                {
                    if (!childGroupNodePort.Exists(x => x.fieldName == port.fieldName))
                    {
                        target.RemoveDynamicPort(port);
                    }
                }

                //add
                foreach (var port in childGroupNodePort)
                {
                    if (!target.HasPort(port.fieldName))
                    {
                        target.AddDynamicOutput(port.ValueType, port.connectionType, port.typeConstraint,
                            port.fieldName);

                        EditorUtility.SetDirty(target);
                        serializedObject.ApplyModifiedProperties();
                        serializedObject.Update();

                        _dynamicOut.list = target.DynamicPorts.ToList();
                    }
                }
            }
        }

        ChildGroupNode _getChildGroupNode(IcSkillGroup skillGroup)
        {
            if (!skillGroup)
            {
                return null;
            }
            
            foreach (var node in skillGroup.nodes)
            {
                if (node is ChildGroupNode childGroupNode)
                {
                    return childGroupNode;
                }
            }

            return null;
        }

        private void _listSetting(ReorderableList list)
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

        private void _check()
        {
            if (rootNode == null) rootNode = target as ChildGroupNode;
        }
    }
}