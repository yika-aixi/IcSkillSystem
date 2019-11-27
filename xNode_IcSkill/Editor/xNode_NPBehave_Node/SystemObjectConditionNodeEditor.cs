using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Nodes.Editor.Utils;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator;
using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    [CustomNodeEditor(typeof(SystemObjectConditionNode))]
    public class SystemObjectConditionNodeEditor : ANPBehaveNodeEditor<SystemObjectConditionNode,Condition>
    {
        private SystemObjectConditionNode _valueNode;
        private NodePort _aInput;
        private NodePort _bInput;
        
        private static SimpleTypeSelectPopupWindow windowContent;

        protected override void OnInit()
        {
            _valueNode = (SystemObjectConditionNode) target;
            
            if (windowContent == null)
            {
                List<Type> types = new List<Type>();
                
                foreach (var unityRuntimeType in TypeUtil.UnityRuntimeTypes)
                {
                    if (typeof(ValueNode).IsAssignableFrom(unityRuntimeType))
                    {
                        var valueField = unityRuntimeType.GetField("_value", BindingFlags.Instance | BindingFlags.NonPublic);

                        if (valueField != null)
                        {
                            types.Add(valueField.FieldType);
                        }
                    }
                }
                
                windowContent = new SimpleTypeSelectPopupWindow(true,types);
            }

            _refreshInputPort();
            
            windowContent.OnChangeTypeSelect = type =>
            {
                _aInput.ValueType = type;
                _bInput.ValueType = type;
                
                windowContent.editorWindow.Close();
                serializedObject.ApplyModifiedProperties();
                serializedObject.UpdateIfRequiredOrScript();
            };
        }

        private void _refreshInputPort()
        {
            _aInput = _valueNode.GetInputPort(SystemObjectConditionNode.AInputName);
            _bInput = _valueNode.GetInputPort(SystemObjectConditionNode.BInputName);
        }

        protected override void DrawBody()
        {
            if (_aInput == null && _bInput == null)
            {
                _valueNode.AddDynamicInput(typeof(object), fieldName: SystemObjectConditionNode.AInputName);
                _valueNode.AddDynamicInput(typeof(object), fieldName: SystemObjectConditionNode.BInputName);
                _refreshInputPort();
            }
            
            base.DrawBody();
            
            if (GUILayout.Button("Change Type"))
            {
                UnityEditor.PopupWindow.Show(new Rect(GetCurrentMousePosition(), new Vector2(0, 0)),
                    windowContent);
            }
        }
    }
}