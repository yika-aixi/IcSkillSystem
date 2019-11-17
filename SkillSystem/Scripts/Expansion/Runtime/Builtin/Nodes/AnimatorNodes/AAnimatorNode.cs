//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月17日-22:06
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using UnityEngine;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class AAnimatorNode:ANPBehaveNode<Action>
    {
        protected Animator Anim;
       
        protected override Action GetOutValue()
        {
            Anim = SkillGroup.Owner.GetComponent<Animator>();
            
            return CreateAction();
        }

        protected abstract Action CreateAction();
    }
}