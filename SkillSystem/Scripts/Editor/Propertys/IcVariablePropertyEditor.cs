using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor
{
    [CustomPropertyDrawer(typeof(AValueInfo), true)]
    public class IcVariablePropertyEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            #if !UNITY_2020_1
            var valueProperty = property.FindPropertyRelative(nameof(ValueInfo<object>.Value));
            EditorGUI.PropertyField(position,valueProperty,label);
            #else
                EditorGUI.PropertyField(position,property,label);
            #endif
        }
    }
}
