using CabinIcarus.IcSkillSystem.Expansion.Builtin.Component;
using CabinIcarus.IcSkillSystem.Runtime.Nodes.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Get Owner")]
    public class GetOwnerBlackboardNode : BlackboardNode
    {
        [SerializeField, Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        [PortTooltipMethodOrPropertyGet(nameof(_port))]
        private bool _useUnityContextClock;

        protected override Blackboard GetOutValue()
        {
            var blackboard = SkillGroup.Owner.GetComponent<SelfBlackBoardComponent>();

            if (!blackboard)
            {
                blackboard = SkillGroup.Owner.AddComponent<SelfBlackBoardComponent>();
                blackboard.UseUnityContextClock = GetInputValue(nameof(_useUnityContextClock), _useUnityContextClock);
            }

            if (blackboard.Blackboard == null)
            {
                blackboard.Init();
            }

            return blackboard.Blackboard;
        }

        private string _port =>
            $"When the owner does not have the `{nameof(SelfBlackBoardComponent)}` component, `Clock` uses `UnityContext` or self when adding the ` {nameof(SelfBlackBoardComponent)}` component. true uses UnityContent, false to use self";
    }
}