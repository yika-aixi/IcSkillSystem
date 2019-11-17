//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月17日-00:15
//CabinIcarus.IcSkillSystem.xNodeIc.Editor

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    public class ValueEditPopupWindow:PopupWindowContent
    {
        public IcSkillGroup.ValueS ValueS;

        public Action OnEdit;
        private List<FieldInfo> _unityObjFields = new List<FieldInfo>();
        public override void OnGUI(Rect rect)
        {
            EditorGUILayout.HelpBox(ValueS.ValueType.FullName,MessageType.Info);

            var pubField = ValueS.ValueType.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(x=> !x.IsNotSerialized);
            
            var preField =  ValueS.ValueType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(x=>x.GetCustomAttribute<SerializeField>() != null);

            var fields = pubField.Concat(preField);
            _unityObjFields.Clear();
            
            foreach (var field in fields)
            {
                if (typeof(Object).IsAssignableFrom(field.FieldType))
                {
                    _unityObjFields.Add(field);
                    continue;    
                }
                
                _drawNonUnityValue<int>(field, x => EditorGUILayout.DelayedIntField(field.Name,x));
                _drawNonUnityValue<float>(field, x => EditorGUILayout.DelayedFloatField(field.Name,x));
                _drawNonUnityValue<double>(field, x => EditorGUILayout.DelayedDoubleField(field.Name,x));
                _drawNonUnityValue<long>(field, x => EditorGUILayout.LongField(field.Name,x));
                _drawNonUnityValue<string>(field, x => EditorGUILayout.DelayedTextField(field.Name,x));
                _drawNonUnityValue<Vector2>(field, x => EditorGUILayout.Vector2Field(field.Name,x));
                _drawNonUnityValue<Vector2Int>(field, x => EditorGUILayout.Vector2IntField(field.Name,x));
                _drawNonUnityValue<Vector3>(field, x => EditorGUILayout.Vector3Field(field.Name,x));
                _drawNonUnityValue<Vector3Int>(field, x => EditorGUILayout.Vector3IntField(field.Name,x));
                _drawNonUnityValue<Vector4>(field, x => EditorGUILayout.Vector4Field(field.Name,x));
                _drawNonUnityValue<Color>(field, x => EditorGUILayout.ColorField(field.Name,x));
                _drawNonUnityValue<AnimationCurve>(field, x => EditorGUILayout.CurveField(field.Name,x));
                _drawNonUnityValue<Bounds>(field, x => EditorGUILayout.BoundsField(field.Name,x));
                _drawNonUnityValue<BoundsInt>(field, x => EditorGUILayout.BoundsIntField(field.Name,x));
                _drawNonUnityValue<Rect>(field, x => EditorGUILayout.RectField(field.Name,x));
                _drawNonUnityValue<RectInt>(field, x => EditorGUILayout.RectIntField(field.Name,x));
                _drawNonUnityValue<Enum>(field, x => EditorGUILayout.EnumFlagsField(field.Name,x));
                _drawNonUnityValue<Gradient>(field, x => EditorGUILayout.GradientField(field.Name,x));
            }
            
            foreach (var field in _unityObjFields)
            {
                EditorGUILayout.HelpBox($"{field.Name} is Unity Object Type,Unable Serialization.",MessageType.Warning);
            }
        }

        private object _fieldValue;
        private object _obj;
        private void _drawNonUnityValue<T>(FieldInfo fieldInfo, Func<T, T> drawValueAction)
        {
            if (!typeof(T).IsAssignableFrom(fieldInfo.FieldType))
            {
                return;
            }
            
            EditorGUI.BeginChangeCheck();
            {
                _obj = ValueS.GetValue();
                _fieldValue = fieldInfo.GetValue(_obj);
                _fieldValue = drawValueAction((T) _fieldValue);
            }
            if (EditorGUI.EndChangeCheck())
            {
                fieldInfo.SetValue(_obj,_fieldValue);
                ValueS.SetValue(_obj);
                OnEdit?.Invoke();
            }
        }
    }
}