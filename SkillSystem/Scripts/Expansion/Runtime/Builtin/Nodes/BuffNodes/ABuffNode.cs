using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes.BuffNodes
{
    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Buff")]
    public abstract class ABuffNode:ANPBehaveNode<Action>
    {
        
        
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private IIcSkSEntity _entity;

        [Input(ShowBackingValue.Never,ConnectionType.Multiple,TypeConstraint.Inherited)]
        [PortTooltip("buffs")]
        private IBuffDataComponent _buffs;

        protected IIcSkSEntity Entity { get; private set;}
        protected IBuffDataComponent[] Buffs { get; private set;}
        protected sealed override Action GetOutValue()
        {
            Entity = GetInputValue(nameof(_entity), _entity);
            
            Buffs = GetInputValues<IBuffDataComponent>(nameof(_buffs),null);
            
            return new Action(Execute);
        }

        protected abstract void Execute();
    }
}