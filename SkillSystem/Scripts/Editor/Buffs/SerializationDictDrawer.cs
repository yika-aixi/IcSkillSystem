using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor
{
    public abstract class SerializationDictDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            if (GUI.Button(position,"Add Variable"))
            {
                var keys = property.FindPropertyRelative(SerializationDict<object, object>.KeysFieldName);
                
                keys.InsertArrayElementAtIndex(keys.arraySize);
            }
        }
    }
}