using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Observer")]
    public class ObserverNode:ADecoratorNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited,typeof(IActionExecuteNode))]
        private ANPNode _onStart;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited,typeof(IActionExecuteNode<bool>))]
        private ANPNode _onStop;

        protected override void CreateNode()
        {
            base.CreateNode();

            IActionExecuteNode ex = (IActionExecuteNode) GetInputValue(nameof(_onStart),_onStart);

            IActionExecuteNode<bool> exf = (IActionExecuteNode<bool>) GetInputValue(nameof(_onStop), _onStop);
            
            Node = new Observer(ex.Execute,exf.Execute,DecorateeNode.Node);
        }
    }
}