using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Blackboard Query")]
    public class BlackboardQueryNode:AObservingDecoratorNode
    {
        [SerializeField]
        private string[] _keys;

        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited,typeof(IFuncExecuteNode<bool>))]
        [PortTooltip("实现"+nameof(IFuncExecuteNode<bool>)+"的节点")]
        private ANPNode _isConditionMet;

        protected override void CreateNode()
        {
            base.CreateNode();
            
            Node = new BlackboardQuery(_keys,Stops,((IFuncExecuteNode<bool>)_isConditionMet).Execute,DecorateeNode.Node);
        }
    }
}