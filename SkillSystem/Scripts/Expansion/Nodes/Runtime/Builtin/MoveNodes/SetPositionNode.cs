using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Move/Set Position")]
    public class SetPositionNode:AMoveNode
    {
        [SerializeField]
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltip("New Postion")]
        private Vector3 _pos;

        private void _setPos()
        {
            Tran.position = GetInputValue(nameof(_pos),_pos);
        }

        protected override Action.Result Move(Action.Request arg)
        {
            _setPos();
            
            return Action.Result.SUCCESS;
        }
    }
}