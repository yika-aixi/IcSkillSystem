using CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace UnityEditor
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(ValueNode))]
    public class ValueNodeEditor:NodeEditor
    {
        private ValueNode _valueNode;
        private TypeSelectPopupWindow windowContent;
        protected override void Init()
        {
            _valueNode = (ValueNode) target;
            windowContent = new TypeSelectPopupWindow();
            windowContent.OnChangeTypeSelect = type =>
            {
                _valueNode.ValueType = type;
                windowContent.editorWindow.Close();
            };
        }

        public override void OnBodyGUI()
        {
            var port = target.GetOutputPort(ValueNode.ValueOutPutPortName);

            if (port == null)
            {
                target.AddDynamicOutput(_valueNode.ValueType, fieldName: ValueNode.ValueOutPutPortName);
                return;
            }

            if (port.ValueType != _valueNode.ValueType)
            {
                port.ValueType = _valueNode.ValueType;
            }
            
            base.OnBodyGUI();
            
            if (GUILayout.Button("Change Type"))
            {
                UnityEditor.PopupWindow.Show(new Rect(GetCurrentMousePosition(),new Vector2(0,0)), windowContent);
            }
            
        }
    }
}