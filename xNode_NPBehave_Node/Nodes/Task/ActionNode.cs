using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;
using XNode;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Action")]
    public class ActionNode:NPBehaveNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("动作节点 - IActionNode")]
        private NPBehaveNode _executeNode;

        [SerializeField,Output]
        [PortTooltip("Action Node")]
        private ActionNode _actionNode;

        public override object GetValue(NodePort port)
        {
            _actionNode = (ActionNode) base.GetValue(port);

            return _actionNode;
        }

        protected override void CreateNode()
        {
            var execute = GetInputValue(nameof(_executeNode), _executeNode);
            switch (execute)
            {
                case IActionExecuteNode action:
                    Node = new Action(action.Execute);      
                    return;
                case ISingleFrameFuncExecuteNode action:
                    Node = new Action(action.Execute);      
                    return;
                case IMultiFrameFuncExecuteNode action:
                    Node = new Action(action.Execute);      
                    return;
                case IMultiFrameFunc2ExecuteNode action:
                    Node = new Action(action.Execute);      
                    return;
            }
        }
    }
}