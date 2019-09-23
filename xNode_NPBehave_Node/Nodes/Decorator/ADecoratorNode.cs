using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    public abstract class ADecoratorNode:ANPBehaveNode
    {
        [SerializeField,Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        protected ANPBehaveNode DecorateeNode;
        
        [SerializeField,Output()]
        private ADecoratorNode _output;
        
        protected override void CreateNode()
        {
            _output = this;
            DecorateeNode = GetInputValue(nameof(DecorateeNode), DecorateeNode);
        }
    }
}