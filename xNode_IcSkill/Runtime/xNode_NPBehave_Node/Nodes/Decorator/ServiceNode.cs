using NPBehave;
using UnityEngine;
using Action = System.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Service")]
    public class ServiceNode:ADecoratorNode<Service>
    {
        [SerializeField]
        private float _interval;

        [SerializeField] 
        private float _randomVariation;

        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Action _service;

        protected override Service GetDecoratorNode()
        {
            _service = GetInputValue(nameof(_service), _service);
            
            return new Service(_interval, _randomVariation,_service, DecorateeNode);
        }
    }
}