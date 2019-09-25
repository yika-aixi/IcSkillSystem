using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using NPBehave;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(ANPBehaveNode<Node>))]
    public class NPBehaveNodeEditor : NodeEditor
    {
        private ANPBehaveNode<Node> _node;
        private Color _backColor;

        protected bool Error;
        protected bool Warning;

        public void _check()
        {
            if (_node == null) _node = target as ANPBehaveNode<Node>;
            _backColor = GUI.color;
        }

        public override Color GetTint()
        {
            if (Error)
            {
                return Color.red;
            }

            if (Warning)
            {
                return Color.yellow;
            }

            return base.GetTint();
        }

        public sealed override void OnCreate()
        {
            _check();
            OnInit();
        }

        protected virtual void OnInit()
        {
        }

        public sealed override void OnBodyGUI()
        {
            serializedObject.Update();
            {
                _reSetColor();
                ColorCheck();
                {
                    DrawBody();
                }
            }
            serializedObject.ApplyModifiedProperties();
        }

        protected virtual void DrawBody()
        {
            base.OnBodyGUI();
        }

        protected virtual void ColorCheck()
        {
            var NPBNodeInputs = _node.Inputs.Where(x => typeof(Node).IsAssignableFrom(x.ValueType));

            foreach (var nodePort in NPBNodeInputs)
            {
                if (nodePort.ConnectionCount == 0)
                {
                    Error = true;
                }
            }
        }

        private void _reSetColor()
        {
            Error = false;
            Warning = false;
        }
    }
}