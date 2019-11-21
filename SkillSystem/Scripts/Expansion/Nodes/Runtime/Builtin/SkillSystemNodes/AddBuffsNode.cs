using NPBehave;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes.BuffNodes
{
    public class AddBuffsNode:ASKNode
    {
        [Input(ShowBackingValue.Unconnected,ConnectionType.Multiple,TypeConstraint.Inherited)]
        private string _buffs;

        private string[] _getBuffs => GetInputValues<string>(nameof(_buffs), null);
        
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
                    
                }
            }
        }
    }
}