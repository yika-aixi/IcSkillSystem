//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月17日-22:09
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Animator/Trigger")]
    public class AnimatorTriggerNode:AAnimatorNode
    {
        //todo 需要editor 进行对应的显示/隐藏
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private bool _useHash;

        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private string _name;

        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private int _hash;
        
        protected override Action CreateAction()
        {
            return new Action(_trigger);
        }

        private void _trigger()
        {
            _useHash = GetInputValue(nameof(_useHash),_useHash);

            if (_useHash)
            {
                GetInputValue(nameof(_hash),_hash);

                Anim.SetTrigger(_hash);
            }else
            {
                _name = GetInputValue(nameof(_name),_name);

                Anim.SetTrigger(_name);
            }
        }
    }
}