using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor
{
    //todo 暂时取消绘制,需要查下自定义绘制这个展开或者绘制属性,但是属性占了2行并没有设置占用2行,导致后续gui会覆盖在之上
//    [CustomPropertyDrawer(typeof(AValueInfo), true)]
    public class IcVariablePropertyEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            //2019.2.0 May lead to incorrect position of subsequent element at some point (eg. xNode)
            #if !UNITY_2020_1 && !UNITY_2019_2 && !UNITY_2019_3
                var valueProperty = property.FindPropertyRelative(nameof(ValueInfo<object>.Value));
                EditorGUI.PropertyField(position,valueProperty,label,true);
            #else
                EditorGUI.PropertyField(position,property,label,true);
            #endif
        }
    }
}
