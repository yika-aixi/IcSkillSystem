using System;
using CabinIcarus.IcSkillSystem.Runtime.Nodes;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    public abstract class ANPNodeEditor<T,AT>:NodeEditor where T : ANPNode<AT>
    {
        protected T TNode;

        protected bool Error;
        protected bool Warning;

        public void _check()
        {
            try
            {
                if (TNode == null)
                    TNode = (T) target;

            }
#pragma warning disable 168
            catch (Exception e)
#pragma warning restore 168
            {
                Debug.LogError(target);
            }           
        }

        public override Color GetTint()
        {
            if (Error)
            {
                return new Color(205 / 255f,20 / 255f,25 / 255f);
            }

            if (Warning)
            {
                return Color.yellow;
            }

            return base.GetTint();
        }

        protected sealed override void Init()
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

        protected abstract void ColorCheck();

        private void _reSetColor()
        {
            Error = false;
            Warning = false;
        }
    }
}