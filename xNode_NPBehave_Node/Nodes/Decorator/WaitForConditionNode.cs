using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/WaitForCondition")]
    public class WaitForConditionNode:ADecoratorNode
    {
        [SerializeField] 
        private float _checkInterval;
        
        [SerializeField] 
        private float _randomVariance;

        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited,typeof(IFuncExecuteNode<bool>))]
        private ANPNode _condition;

        protected override void CreateNode()
        {
            base.CreateNode();

            IFuncExecuteNode<bool> condition = (IFuncExecuteNode<bool>) GetInputValue(nameof(_condition), _condition);
            
            Node = new WaitForCondition(condition.Execute, _checkInterval, _randomVariance, DecorateeNode.Node);
        }
    }
}