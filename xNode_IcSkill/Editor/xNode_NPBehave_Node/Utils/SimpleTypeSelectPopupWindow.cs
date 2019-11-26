using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils
{
    internal class TypeTreeView : TreeView
    {
        class TypeItem:TreeViewItem
        {
            public Type Type { get; }

            public TypeItem(int id, int depth, string displayName, Type type) : base(id, depth, displayName)
            {
                Type = type;
            }
        }
        private readonly IEnumerable<Type> types;
        
        public Action<Type> OnSelect;

        public TypeTreeView(IEnumerable<Type> types,TreeViewState state, MultiColumnHeader multiColumnHeader = null) : base(state, multiColumnHeader)
        {
            this.types = types;
            this.useScrollView = true;
        }
        
        protected override bool CanMultiSelect(TreeViewItem item)
        {
            if (item is TypeItem typeItem)
            {
                OnSelect?.Invoke(typeItem.Type);
            }

            SetSelection(new List<int>(item.id));
            
            return base.CanMultiSelect(item);
        }

        protected override void DoubleClickedItem(int id)
        {
            var item = this.FindItem(id,rootItem);

            if (item.hasChildren)
            {
                SetExpanded(id, true);
            }
        }

        protected override TreeViewItem BuildRoot()
        {
            int depth = -1;
            
            TreeViewItem root = new TreeViewItem(-1,depth);

            int id = 0;
            
            foreach (var type in types)
            {
                var names = type.Assembly.GetName().Name.Split('.');
                depth = 0;

                TreeViewItem last = root;
                foreach (var name in names)
                {
                    if (last.hasChildren)
                    {
                        foreach (var child in last.children)
                        {
                            if (child.depth == depth)
                            {
                                if (child.displayName == name)
                                {
                                    last = child;
                                    goto end;
                                }
                            }
                        }
                    }

                    var ch = new TreeViewItem(id, depth, name);
                    last.AddChild(ch);
                    last = ch;
                    id++;

                    end:
                    depth++;
                }

                last.AddChild(new TypeItem(id,depth,type.Name,type));

                id++;
            }

            return root;
        }
    }
    
    public class SimpleTypeSelectPopupWindow : PopupWindowContent
    {
        private readonly bool _focus;
        private Type _baseType;
        private string _ser;
        private SearchField searchField;
        private TypeTreeView _tree;
        public SimpleTypeSelectPopupWindow(bool focus):this(focus,TypeUtil.GetRuntimeFilterTypes) { }

        public SimpleTypeSelectPopupWindow(bool focus,IEnumerable<Type> types)
        {
            this._focus = focus;
            _tree = new TypeTreeView(types,new TreeViewState());
            _tree.OnSelect = x=> OnChangeTypeSelect?.Invoke(x);
            _tree.Reload();
        }

        public Type BaseType
        {
            get => _baseType;
            set => _baseType = value;
        }

        public override void OnOpen()
        {
            base.OnOpen();
            searchField = new SearchField();
            if (_focus)
            {
                searchField.SetFocus();
            }
        }

        public override void OnClose()
        {
            base.OnClose();
            //todo 不清空吧=-=
            //_ser = string.Empty;
        }

        public Action<Type> OnChangeTypeSelect;

        private Vector2 _pos;
        public override void OnGUI(Rect rect)
        {
            _ser = searchField.OnGUI(new Rect(rect.position,new Vector2(rect.width,20)), _ser);

            if (GUI.changed)
            {
                _tree.searchString = _ser;
            }

            _tree.OnGUI(new Rect(rect.position + new Vector2(0,25),rect.size - new Vector2(0,25)));
        }
    }
}