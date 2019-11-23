using System;
using CabinIcarus.IcSkillSystem.Runtime.Nodes.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Blackboard Query")]
    public class BlackboardQueryNode:AObservingDecoratorNode<BlackboardQuery>
    {
        [SerializeField]
        private string[] _keys;

        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("实现"+nameof(Func<bool>)+"的节点")]
        private Func<bool> _isConditionMet;

        protected override BlackboardQuery GetDecoratorNode()
        {
            return new BlackboardQuery(_keys,Stops,_isConditionMet,DecorateeNode);
        }
    }
}