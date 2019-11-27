//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月22日-00:08
//Assembly-CSharp

using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Condition")]
    public class ConditionNode:AObservingDecoratorNode<Condition>
    {
        [Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("实现了`IFuncExecuteNode`接口的Node")]
        private Func<bool> _conditionNode;

        [SerializeField]
        private float _checkInterval;

        [SerializeField]
        private float _randomVariance;

        protected override Condition GetDecoratorNode()
        {
            _conditionNode = GetInputValue(nameof(_conditionNode), _conditionNode);

            return new Condition(_conditionNode,Stops,_checkInterval,_randomVariance,DecorateeNode);
        }
    }
}