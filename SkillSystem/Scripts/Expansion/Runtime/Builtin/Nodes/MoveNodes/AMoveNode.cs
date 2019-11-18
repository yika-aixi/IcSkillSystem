using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class AMoveNode:ANPBehaveNode<Action>
    {
        [SerializeField]
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltipMethodOrPropertyGet(nameof(Tooltip))]
        private Vector3 _destination;

        protected Vector3 Destination => GetInputValue(nameof(_destination), _destination);
        protected Transform Tran => SkillGroup.Owner.transform;
        
        protected virtual string Tooltip => "Destination";
    }
}