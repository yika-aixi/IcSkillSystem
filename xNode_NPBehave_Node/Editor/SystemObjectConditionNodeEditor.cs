using System;
using CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator;
using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [CustomNodeEditorAttribute(typeof(SystemObjectConditionNode))]
    public class ConditionNodeEditor : ANPBehaveNodeEditor<SystemObjectConditionNode,Condition>
    {
        private SystemObjectConditionNode _valueNode;
        private NodePort _aInput;
        private NodePort _bInput;
        
        private TypeSelectPopupWindow windowContent;

        protected override void OnInit()
        {
            _valueNode = (SystemObjectConditionNode) target;

            windowContent = new TypeSelectPopupWindow(true);
            
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