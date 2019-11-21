using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes.BuffNodes
{
    public class AddBuffsBlackboardNode:ASKNode
    {
        [Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("no input use Root Blackboard")]
        private Blackboard _blackboard;
        
        [Input(ShowBackingValue.Unconnected,ConnectionType.Multiple,TypeConstraint.Inherited)]
        [PortTooltip("support multi Connection")]
        private string _keys;

        private string[] _getKeys => GetInputValues<string>(nameof(_keys), null);
        
        Blackboard _getBlackboard
        {
            get
            {
                var blackboard = GetInputValue(nameof(_blackboard), _blackboard);

                if (blackboard == null)
                {
                    blackboard = SkillGroup.RootNode.Blackboard;
                }

                return blackboard;
            }
        }

        protected override Task GetTask()
        {
            return new Action(_addBuff);
        }

        private void _addBuff()
        {
            if (_getKeys != null)
            {
                foreach (var key in _getKeys)
                {
                    var buff = _getBlackboard.Get<IBuffDataComponent>(key);
                    
                    if (buff != null)
                    {
                        BuffFactory.AddBuff(EntityManager, Entity, buff.GetType().FullName, buff);
                    }
                }
            }
        }
    }
}