using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_Nodes
{
    [CustomNodeEditorAttribute(typeof(DynamicValueNode))]
    public class ValueNodeEditor:NodeEditor
    {
        private DynamicValueNode _valueNode;
        private NodePort _valueOutPut;
        
        private SimpleTypeSelectPopupWindow windowContent;

        public override void OnInit()
        {
            _valueNode = (DynamicValueNode) target;
            _valueOutPut = _valueNode.GetOutputPort(DynamicValueNode.ValueOutPutPortName);

            if (_valueOutPut != null)
            {
                if (_valueOutPut.ValueType == null)
                {
                    _valueOutPut.ValueType = typeof(object);
                }
            }
            
            windowContent = new SimpleTypeSelectPopupWindow(true);
            
            windowContent.OnChangeTypeSelect = type =>
            {
                _valueOutPut.ValueType = type;
                windowContent.editorWindow.Close();
                serializedObject.ApplyModifiedProperties();
                serializedObject.UpdateIfRequiredOrScript();
            };
        }

        public override void OnBodyGUI()
        {
            serializedObject.Update();
            {
                if (_valueOutPut == null)
                {
                    _valueOutPut = _valueNode.AddDynamicOutput(typeof(object), fieldName: DynamicValueNode.ValueOutPutPortName);
                }
                
                base.OnBodyGUI();
                
                if (GUILayout.Button("Change Type"))
                {
                    windowContent.BaseType = _valueNode.BaseType;
                    
                    UnityEditor.PopupWindow.Show(new Rect(GetCurrentMousePosition(), new Vector2(0, 0)),
                        windowContent);
                }
                
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}