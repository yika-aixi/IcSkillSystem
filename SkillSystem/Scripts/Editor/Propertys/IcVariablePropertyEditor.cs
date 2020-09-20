using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor
{
    [CustomPropertyDrawer(typeof(AValueInfo), true)]
    public class IcVariablePropertyEditor : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var valueProperty = property.FindPropertyRelative(nameof(ValueInfo<object>.Value));
            
            if (valueProperty == null)
            {
                return base.GetPropertyHeight(property,  label);
            }
            
            return EditorGUI.GetPropertyHeight(valueProperty,true);
        }

        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            var valueProperty = property.FindPropertyRelative(nameof(ValueInfo<object>.Value));
            
            if (valueProperty == null)
            {
                EditorGUI.LabelField(position,label);
                return;
            }
            
            position.height = EditorGUI.GetPropertyHeight(valueProperty,true);
            label.text = property.displayName;
            EditorGUI.PropertyField(position, valueProperty, label, true);

        }
    }
}
