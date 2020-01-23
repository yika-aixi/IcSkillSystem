//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月18日-21:03
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Animator/Bool")]
    public class AnimationBoolNode:AAnimatorSetXXXNode
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private IcVariableBoolean _value;
        
        protected override void NameMode()
        {
            Anim.SetBool(Name,GetInputValue(nameof(_value),_value));
        }

        protected override void HashMode(in int hash)
        {
            Anim.SetBool(hash,GetInputValue(nameof(_value),_value));
        }
    }
}