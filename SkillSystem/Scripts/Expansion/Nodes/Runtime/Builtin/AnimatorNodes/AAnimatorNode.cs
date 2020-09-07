//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月17日-22:06
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class AAnimatorNode:ANPBehaveNode<Task>
    {
        protected Animator Anim { get; private set; }

        public override void OnSetOwner()
        {
            Anim = SkillGraph.Owner.GetComponent<Animator>();
        }

        protected sealed override Task CreateOutValue()
        {
            return CreateAction();
        }

        protected abstract Task CreateAction();
    }
}