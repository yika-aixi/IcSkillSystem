//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-23:59
//Assembly-CSharp

using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    public abstract class AObservingDecoratorNode:ANPBehaveNode
    {
        [SerializeField] 
        protected Stops Stops;

        [SerializeField,Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        protected ANPBehaveNode DecorateeNode;

        [SerializeField,Output()]
        protected AObservingDecoratorNode _output;

        protected override void CreateNode()
        {
            _output = this;
            
            DecorateeNode = GetInputValue(nameof(DecorateeNode), DecorateeNode);
        }
    }
}