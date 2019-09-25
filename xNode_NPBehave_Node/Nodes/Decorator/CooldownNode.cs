using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Cooldown")]
    public class CooldownNode:ADecoratorNode<Cooldown>
    {
        [SerializeField]
        private float _cooldownTime;
        [SerializeField]
        private float _randomVariation;

        [SerializeField]
        private bool _startAfterDecoratee;
        [SerializeField]
        private bool _resetOnFailiure;

        protected override Cooldown GetDecoratorNode()
        {
            return new Cooldown(_cooldownTime,_randomVariation,_startAfterDecoratee,_resetOnFailiure,DecorateeNode);
        }
    }
}