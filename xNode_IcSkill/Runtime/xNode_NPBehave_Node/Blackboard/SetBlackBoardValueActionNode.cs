//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月18日-02:59
//CabinIcarus.IcSkillSystem.xNodeIc

using CabinIcarus.IcSkillSystem.Runtime.Nodes.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Set Blackboard Value")]
    public class SetBlackBoardValueActionNode:ANPBehaveNode<Action>
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("黑板")]
        private Blackboard _blackBoard;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("New Value")]
        private object _newValue;
        
        [SerializeField]
        private string _key;
        
        protected override Action GetOutValue()
        {
            return  new Action(_set);
        }

        private void _set()
        {
            var blackboard = GetInputValue(nameof(_blackBoard), _blackBoard);

            var newValue = GetInputValue(nameof(_newValue),_newValue);
            
            blackboard?.Set(_key,newValue);
        }
    }
}