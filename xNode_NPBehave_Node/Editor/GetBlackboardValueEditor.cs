//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils;
//using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
//using UnityEditor;
//using UnityEditor.IMGUI.Controls;
//using UnityEngine;
//using XNodeEditor;
//
//namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
//{
////    [NodeEditor.CustomNodeEditorAttribute(typeof(GetBlackboardValue))]
//    public class GetBlackboardValueEditor:NodeEditor
//    {
//        private TypeSelectPopupWindow windowContent;
//        private Type _selectType;
//
//        public override void OnCreate()
//        {
//            base.OnCreate();
//            windowContent = new TypeSelectPopupWindow();
//            windowContent.OnChangeTypeSelect = type =>
//            {
//                var fieldName = GetBlackboardValue.TypeValueOutPortName;
//                
//                if (_selectType != null)
//                {
//                    if (target.GetPort(fieldName) != null)
//                    {
//                        target.RemoveDynamicPort(fieldName);
//                    }
//                }
//
//                _selectType = type;
//
//                target.AddDynamicOutput(_selectType, fieldName: fieldName);
//                
//                windowContent.editorWindow.Close();
//            };
//        }
//
//        public override void OnBodyGUI()
//        {
//            base.OnBodyGUI();
//            
//            if (GUILayout.Button("Open"))
//            {
//                UnityEditor.PopupWindow.Show(new Rect(GetCurrentMousePosition(),new Vector2(500,300)), windowContent);
//            }
//        }
//    }
//}