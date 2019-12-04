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
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    class ValueEditTree:TreeView
    {
        private readonly object _target;
        private bool _containProperty;
        public Action<object> OnValueChange;
        /// <summary>
        /// need <see cref="ContainProperty"/> be true
        /// </summary>
        private bool _containPrivateProperty;
        class MemberInfoItem : TreeViewItem
        {
            public object Obj { get; }
            
            public MemberInfo Info { get; }

            public bool IsSimpleValue { get; }

            public MemberInfoItem(int id, int depth, string displayName, object obj, MemberInfo info,bool isSimpleValue) : base(id, depth, displayName)
            {
                Obj = obj;
                Info = info;
                IsSimpleValue = isSimpleValue;
            }
        }

        public ValueEditTree(object target,TreeViewState state, MultiColumnHeader multiColumnHeader = null, bool containProperty = true, bool containPrivateProperty = true) : base(state, multiColumnHeader)
        {
            _target = target;
            _containProperty = containProperty;
            _containPrivateProperty = containPrivateProperty;
            useScrollView = true;
        }

        /// <summary>
        /// need <see cref="ContainProperty"/> be true
        /// </summary>
        public bool ContainPrivateProperty
        {
            get => _containPrivateProperty;
            set
            {
                _containPrivateProperty = value;
                Reload();
            }
        }

        public bool ContainProperty
        {
            get => _containProperty;
            set
            {
                _containProperty = value;
                Reload();
            }
        }

        protected override TreeViewItem BuildRoot()
        {
            int id = -1;
            int depth = -1;
            TreeViewItem root = new TreeViewItem(id++,depth++,_target.GetType().Name);
            _collect(_target,root,ref id,ref depth);
            return root;
        }
        private List<MemberInfo> _unityObjFields = new List<MemberInfo>();
        private IEnumerable<MemberInfo> _memberInfos;

        private void _collect(object target, TreeViewItem parent,ref int id,ref int depth)
        {
            var type = target.GetType();
            var pubField = type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => !x.IsNotSerialized);

            var preField = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.GetCustomAttribute<SerializeField>() != null);

            _memberInfos = pubField.Concat(preField);

            if (ContainProperty)
            {
                var pubPro =
                    type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                        .Where(x => x.CanWrite);

                _memberInfos = _memberInfos.Concat(pubPro);

                if (ContainPrivateProperty)
                {
                    var prePro = type
                        .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty)
                        .Where(x => x.CanWrite)
                        .Where(x => x.GetCustomAttribute<SerializeField>() != null);

                    _memberInfos = _memberInfos.Concat(prePro);
                }
            }
            
            foreach (var info in _memberInfos)
            {
                FieldInfo fieldInfo = null;
                PropertyInfo propertyInfo = null;
                var isField = info.MemberType == MemberTypes.Field;

                if (isField)
                {
                    fieldInfo = (FieldInfo) info;
                    if (_isSimple(fieldInfo.FieldType))
                    {
                        parent.AddChild(new MemberInfoItem(id++,depth,fieldInfo.Name,target,info,true));
                    }
                    else
                    {
                        var child = new MemberInfoItem(id++, depth++, fieldInfo.Name, target, info, false);
                        parent.AddChild(child);
                        _collect(fieldInfo.GetValue(target),child,ref id,ref depth);
                        depth--;
                    }
                }
                else
                {
                    propertyInfo = (PropertyInfo) info;
                    if (_isSimple(propertyInfo.PropertyType))
                    {
                        parent.AddChild(new MemberInfoItem(id++,depth,propertyInfo.Name,target,info,true));
                    }
                    else
                    {
                        var child = new MemberInfoItem(id++, depth++, propertyInfo.Name, target, info, false);
                        parent.AddChild(child);
                        _collect(propertyInfo.GetValue(target),child,ref id,ref depth);
                        depth--;
                    }
                }
            }
        }
        
        bool _isSimple(Type type)
        {
            return type.IsPrimitive 
                   || type.IsEnum
                   || type == typeof(string)
                   || type == typeof(decimal);
        }

        protected override void DoubleClickedItem(int id)
        {
            var item = FindItem(id,rootItem);

            if (item.hasChildren)
            {
                SetExpanded(id, true);
            }
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            if (args.item is MemberInfoItem memberInfoItem && memberInfoItem.IsSimpleValue)
            {
                var rect = args.rowRect;
                var label = args.label;
                EditorGUI.indentLevel += memberInfoItem.depth;
                _drawNonUnityValue<int>(memberInfoItem, x => EditorGUI.IntField(rect,label, x));
                _drawNonUnityValue<float>(memberInfoItem, x => EditorGUI.FloatField(rect,label, x));
                _drawNonUnityValue<double>(memberInfoItem, x => EditorGUI.DoubleField(rect,label, x) );
                _drawNonUnityValue<long>(memberInfoItem, x => EditorGUI.LongField(rect,label, x) );
                _drawNonUnityValue<string>(memberInfoItem, x => EditorGUI.DelayedTextField(rect,label, x) );
                _drawNonUnityValue<Vector2>(memberInfoItem, x => EditorGUI.Vector2Field(rect,label, x) );
                _drawNonUnityValue<Vector2Int>(memberInfoItem, x => EditorGUI.Vector2IntField(rect,label, x) );
                _drawNonUnityValue<Vector3>(memberInfoItem, x => EditorGUI.Vector3Field(rect,label, x) );
                _drawNonUnityValue<Vector3Int>(memberInfoItem, x => EditorGUI.Vector3IntField(rect,label, x) );
                _drawNonUnityValue<Vector4>(memberInfoItem, x => EditorGUI.Vector4Field(rect,label, x) );
                _drawNonUnityValue<Color>(memberInfoItem, x => EditorGUI.ColorField(rect,label, x) );
                _drawNonUnityValue<AnimationCurve>(memberInfoItem, x => EditorGUI.CurveField(rect,label, x) );
                _drawNonUnityValue<Bounds>(memberInfoItem, x => EditorGUI.BoundsField(rect,label, x) );
                _drawNonUnityValue<BoundsInt>(memberInfoItem, x => EditorGUI.BoundsIntField(rect,label, x) );
                _drawNonUnityValue<Rect>(memberInfoItem, x => EditorGUI.RectField(rect,label, x) );
                _drawNonUnityValue<RectInt>(memberInfoItem, x => EditorGUI.RectIntField(rect,label, x) );
                _drawNonUnityValue<Enum>(memberInfoItem, x => EditorGUI.EnumFlagsField(rect,label, x) );
                _drawNonUnityValue<Gradient>(memberInfoItem, x => EditorGUI.GradientField(rect,label, x) );
                EditorGUI.indentLevel -= memberInfoItem.depth;
            }
            else
            {
                base.RowGUI(args);
            }
        }

        private object _tempValue;
        private void _drawNonUnityValue<T>(MemberInfoItem item,Func<T, T> drawValueAction)
        {
            var isField = item.Info.MemberType == MemberTypes.Field;
            
            FieldInfo fieldInfo = null;

            PropertyInfo propertyInfo = null;

            if (isField)
            {
                fieldInfo = (FieldInfo) item.Info;
            }
            else
            {
                propertyInfo = (PropertyInfo) item.Info;
            }
            
            if (!typeof(T).IsAssignableFrom(isField ? fieldInfo.FieldType : propertyInfo.PropertyType))
            {
                return;
            }
            
            var obj = item.Obj;
            
            EditorGUI.BeginChangeCheck();
            {
                _tempValue = isField ? fieldInfo.GetValue(obj) : propertyInfo.GetValue(obj);
                _tempValue = drawValueAction((T) _tempValue);
            }
            if (EditorGUI.EndChangeCheck())
            {
                if (isField)
                {
                    fieldInfo.SetValue(obj, _tempValue);
                }
                else
                {
                    propertyInfo.SetValue(obj,_tempValue);  
                }

                _updateObject(item.parent,item.Obj);
                
                OnValueChange?.Invoke(_target);
            }
        }

        private void _updateObject(TreeViewItem item, object value)
        {
            if (item.parent == null || item.id == -1)
            {
                return;
            }

            if (item is MemberInfoItem typeItem)
            {
                FieldInfo fieldInfo = null;

                PropertyInfo propertyInfo = null;

                if (typeItem.Info.MemberType == MemberTypes.Field)
                {
                    fieldInfo = (FieldInfo) typeItem.Info;
                    fieldInfo.SetValue(typeItem.Obj,value);
                }
                else
                {
                    propertyInfo = (PropertyInfo) typeItem.Info;
                    propertyInfo.SetValue(typeItem.Obj,value);
                }

                _updateObject(typeItem.parent,typeItem.Obj);
            }
        }
    }

    public class ValueEditPopupWindow : PopupWindowContent
    {
        private ValueS _valueS;
        public Action OnEdit;

        private ValueEditTree _editTree;
        public bool ContainProperty
        {
            get => _editTree?.ContainProperty ?? false;

            set
            {
                if (_editTree != null)
                {
                    _editTree.ContainProperty = value;
                }
            }
        }

        /// <summary>
        /// need <see cref="ContainProperty"/> be true
        /// </summary>
        public bool ContainPrivateProperty
        {
            get => _editTree?.ContainPrivateProperty ?? false;

            set
            {
                if (_editTree != null)
                {
                    _editTree.ContainPrivateProperty = value;
                }
            }
        }

        public ValueS ValueS
        {
            get => _valueS;
            set
            {
                _valueS = value;
                _editTree = new ValueEditTree(_valueS.GetValue(), new TreeViewState());
                _editTree.OnValueChange += x =>
                {
                    _valueS.SetValue(x);
                    OnEdit?.Invoke();
                };
                _editTree.Reload();
            }
        }


        public override void OnGUI(Rect rect)
        {
            EditorGUILayout.HelpBox(ValueS.ValueType.FullName, MessageType.Info);

            var editTreeRect = rect;
            var y = GUILayoutUtility.GetLastRect().size.y + 10;
            editTreeRect.position = new Vector2(0, y);
            editTreeRect.size = new Vector2(editTreeRect.size.x, editTreeRect.size.y - y);
            _editTree.OnGUI(editTreeRect);
        }
    }
}