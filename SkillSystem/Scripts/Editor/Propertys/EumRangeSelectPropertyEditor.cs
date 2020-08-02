//Create: Icarus
//ヾ(•ω•`)o
//2020-08-01 05:34
//CabinIcarus.IcSkillSystem.Editor

using System;
using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcFrameWork.IcSkillSystem.SkillSystem.Scripts.Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.Editor
{
    [CustomPropertyDrawer(typeof(EnumRangeSelectAttribute))]
    public class EumRangeSelectPropertyEditor:PropertyDrawer
    {
        private int _rangeCount;
        private int[] _enums;
        private string[] _enumNames;
        
        private string[] _enumIndexNames;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer && property.propertyType != SerializedPropertyType.Enum)
            {
                EditorGUI.LabelField(position, "field type need is int or enum");
                return;
            }

            bool isEnumField = property.propertyType == SerializedPropertyType.Enum;
            
            var atr = (EnumRangeSelectAttribute) attribute;

            label.text = atr.GetLabel(label.text);

            if (_enums == null)
            {
                var temp = new List<int>();
                var tempStr = new List<string>();
                
                var values = atr.EnumType.GetEnumValues();
                var names = atr.EnumType.GetEnumNames();

                int index = 0;
                
                foreach (var value in values)
                {
                    var iV = (int) value;
                    
                    if (iV >= atr.Min && iV <= atr.Max)
                    {
                        temp.Add(iV);
                        
                        tempStr.Add(names[index]);
                    }

                    if (iV > atr.Max)
                    {
                        break;
                    }
                    
                    ++index;
                }

                _enums = temp.ToArray();
                _enumNames = tempStr.ToArray();

                _rangeCount = _enums.Length;

                if (isEnumField)
                {
                    _enumIndexNames = property.enumNames;
                }
            }

            int iValue = isEnumField ? property.enumValueIndex : property.intValue;

            int enumIndex = -1;

            if (!isEnumField)
            {
                for (var i = 0; i < _rangeCount; i++)
                {
                    if (_enums[i] == iValue)
                    {
                        enumIndex = i;
                        break;
                    }
                }
            }
            else
            {
                var enumName = _enumIndexNames[property.enumValueIndex];

                for (var i = 0; i < _rangeCount; i++)
                {
                    if (enumName == _enumNames[i])
                    {
                        enumIndex = i;
                        break;
                    }
                }
            }

            EditorGUI.BeginChangeCheck();
            {
                enumIndex = EditorGUI.Popup(position, label.text, enumIndex, _enumNames);
            }
            if (EditorGUI.EndChangeCheck())
            {
                if (enumIndex == -1)
                {
                    return;
                }
                if (isEnumField)
                {
                    var enumName = _enumNames[enumIndex];

                    var length = _enumIndexNames.Length;
                
                    for (var i = 0; i < length; i++)
                    {
                        if (property.enumNames[i] == enumName)
                        {
                            property.enumValueIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    property.intValue = _enums[enumIndex];
                }
            }
        }
    }
}