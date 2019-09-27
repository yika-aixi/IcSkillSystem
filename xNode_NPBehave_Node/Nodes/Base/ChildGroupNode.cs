using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/ChildGroup/Main")]
    public class ChildGroupNode:ANPBehaveNode<NPBehave.Node>
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private NPBehave.Node _main;
        
        protected override NPBehave.Node GetOutValue()
        {
            _main = GetInputValue(nameof(_main), _main);

            return _main;
        }
    }
    
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/ChildGroup/Get")]
    public class GetChildGroupNode:ANPBehaveNode<NPBehave.Node>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private IcSkillGroup _group;
        
        protected override NPBehave.Node GetOutValue()
        {
            _group = GetInputValue(nameof(_group), _group);

            return _group.GetChildGroupNode();
        }
    }
}