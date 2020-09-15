//Create: Icarus
//ヾ(•ω•`)o
//2020-09-15 12:01
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [NodeTooltip("Change Animator Speed. https://docs.unity3d.com/ScriptReference/Animator-speed.html")]
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Animator/Change Speed")]
    public class ChangeAnimatorSpeed:AAnimatorNode
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        [SerializeField]
        private ValueInfo<float> _speed;
        
        protected override Task CreateAction()
        {
            return new Action(_play);
        }

        private void _play()
        {
            Anim.speed = GetInputValue(nameof(_speed), _speed);
        }
    }
}