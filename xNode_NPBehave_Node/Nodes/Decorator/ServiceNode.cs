using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Service")]
    public class ServiceNode:ADecoratorNode
    {
        [SerializeField]
        private float _interval;

        [SerializeField] 
        private float _randomVariation;

        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited,typeof(IActionExecuteNode))]
        private ANPNode _service;
        
        protected override void CreateNode()
        {
            base.CreateNode();

            IActionExecuteNode action = (IActionExecuteNode) GetInputValue(nameof(_service), _service);
            
            Node = new Service(_interval, _randomVariation,action.Execute, DecorateeNode.Node);
        }
    }
}