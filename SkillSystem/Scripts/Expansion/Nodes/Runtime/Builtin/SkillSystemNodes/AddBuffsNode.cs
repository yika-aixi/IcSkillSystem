using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes.BuffNodes
{
    public class AddBuffsNode:ASKNode
    {
        [Input(ShowBackingValue.Unconnected,ConnectionType.Multiple,TypeConstraint.Inherited)]
        [PortTooltip("support multi Connection")]
        private IBuffDataComponent _buffs;

        private IBuffDataComponent[] _getBuffs => GetInputValues<IBuffDataComponent>(nameof(_buffs), null);
        
        protected override Task GetTask()
        {
            return new Action(_addBuff);
        }

        private void _addBuff()
        {
            if (_getBuffs != null)
            {
                foreach (var buff in _getBuffs)
                {
                    BuffFactory.AddBuff(EntityManager, Entity, buff.GetType().FullName, buff);
                }
            }
        }
    }
}