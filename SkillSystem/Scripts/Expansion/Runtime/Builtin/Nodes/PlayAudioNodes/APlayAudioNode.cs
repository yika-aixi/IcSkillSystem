//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月17日-23:09
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    
    public abstract class APlayAudioNode:ANPBehaveNode<Action>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private AudioClip _clip;

        protected AudioClip Clip => GetInputValue(nameof(_clip), _clip);
    }
}