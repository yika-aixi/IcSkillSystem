//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:33
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes
{
    public abstract class ANPNode<T>:Node,IIcSkillSystemNode
    {
        public IcSkillGroup SkillGroup { get; set; }

        [Output()]
        public T OutValue;

        public T GetDefaultOutputValue()
        {
            return (T) GetOutputPort(nameof(OutValue)).GetOutputValue();
        }
        
        protected sealed override void Init()
        {
            base.Init();
            
            if (!_editorNoPlay())
            {
                OnInit();
            }
        }

        protected virtual void OnInit()
        {
        }
        
        public sealed override object GetValue(NodePort port)
        {
            if (_editorNoPlay())
            {
                return null;
            }

            if (port == null)
            {
                return null;
            }

            if (port.fieldName == nameof(OutValue))
            {
                OutValue = GetOutValue();

                return OutValue;
            }
            return GetPortValue(port);
        }

        protected virtual object GetPortValue(NodePort port)
        {
            return null;
        }

        bool _editorNoPlay()
        {
#if UNITY_EDITOR
            //没有播放,不执行创建
            if (!Application.isPlaying)
            {
                return true;
            }
#endif
            return false;
        }

        protected abstract T GetOutValue();
    }
    
}