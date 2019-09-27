using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansions.Node
{
    public class MoveTargetNode:ANPNode<Action>
    {
        [Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        private BuffEntity _self;
        
        [Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        private BuffEntity _target;

        protected override Action GetOutValue()
        {
            _target = GetInputValue(nameof(_target),_target);
            _self = GetInputValue(nameof(_self),_self);

            if (!_target || !_self)
            {
                return null;
            }
            
            return new Action(() =>
            {
                _self.MoveTarget(_target);
            });
        }
    }
}