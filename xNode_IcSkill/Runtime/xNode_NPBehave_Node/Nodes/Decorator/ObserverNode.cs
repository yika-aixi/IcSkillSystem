using System;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Observer")]
    public class ObserverNode:ADecoratorNode<Observer>
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private System.Action _onStart;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Action<bool> _onStop;

        protected override Observer GetDecoratorNode()
        {
            _onStart = GetInputValue(nameof(_onStart),_onStart);

            _onStop = GetInputValue(nameof(_onStop), _onStop);
            
            return new Observer(_onStart,_onStop,DecorateeNode);
        }
    }
}