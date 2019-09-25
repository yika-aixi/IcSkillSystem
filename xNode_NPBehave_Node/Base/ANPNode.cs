//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:33
//Assembly-CSharp

using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class ANPNode<T>:Node,ISkillSystemNode
    {
        [Output()]
        public T OutValue;
        
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

            OutValue = GetOutValue();

            return OutValue;
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