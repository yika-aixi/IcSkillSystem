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
    public abstract class ANPNode:Node,ISkillSystemNode
    {
        public sealed override object GetValue(NodePort port)
        {
            
#if UNITY_EDITOR
            //没有播放,不执行创建
            if (!Application.isPlaying)
            {
                return this;
            }
#endif
            CreateNode();

            return this;
        }

        protected abstract void CreateNode();
    }
}