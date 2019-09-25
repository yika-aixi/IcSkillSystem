using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using XNode;
using XNodeEditor;

namespace UnityEditor
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(ValueNode))]
    public class ValueNodeEditor:NodeEditor
    {
        private ValueNode _valueNode;
        public override void OnCreate()
        {
            base.OnCreate();

            _valueNode = (ValueNode) target;
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
        }
    }
}