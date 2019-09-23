//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月22日-00:08
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Condition")]
    public class ConditionNode:AObservingDecoratorNode
    {
        [SerializeField,Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited,baseType:typeof(IFuncExecuteNode<bool>))]
        [PortTooltip("实现了`IFuncExecuteNode`接口的Node")]
        private ANPBehaveNode _conditionNode;

        [SerializeField]
        private float _checkInterval;

        [SerializeField]
        private float _randomVariance;
        
        protected override void CreateNode()
        {
            base.CreateNode();
            
            _conditionNode = GetInputValue(nameof(_conditionNode), _conditionNode);
            
            Node = new Condition(((IFuncExecuteNode<bool>) _conditionNode).Execute,Stops,_checkInterval,_randomVariance,DecorateeNode.Node);
        }
    }
}