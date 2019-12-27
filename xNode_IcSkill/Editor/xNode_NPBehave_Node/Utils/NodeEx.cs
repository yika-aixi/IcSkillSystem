using System.Reflection;
using UnityEditor;
using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor.Utils
{
    public static class NodeEx
    {
        public static void PortRename(this Node self,NodePort port,string newName)
        {
            if (port == null)
            {
                return;
            }
            
            var oldName = port.fieldName;
            
            var fieldNameFieldInfo = port.GetType().GetField(NodePort.FIELDNAMEEDITOR,BindingFlags.Instance | BindingFlags.NonPublic);
            
            fieldNameFieldInfo.SetValue(port,newName);

            SerializedObject nodeSerObj = new SerializedObject(self);

            var portsSer = nodeSerObj.FindProperty(Node.PortFieldName);

            var keysSer = portsSer.FindPropertyRelative(Node.KeysFieldName);

            for (var i = 0; i < keysSer.arraySize; i++)
            {
                if (keysSer.GetArrayElementAtIndex(i).stringValue == oldName)
                {
                    keysSer.GetArrayElementAtIndex(i).stringValue = newName;
                    break;
                }
            }

            nodeSerObj.ApplyModifiedProperties();
            
            EditorUtility.SetDirty(self);
        }
    }
}