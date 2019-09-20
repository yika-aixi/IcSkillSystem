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
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        [PortTooltip("动作节点 - IActionNode")]
        private NPBehaveNode _nodes;

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
            switch (_nodes)
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
        
        public override void OnCreateConnection(NodePort @from, NodePort to)
        {
            if (from.node != this)
            {
                if (!(from.node is IActionNode))
                {
                    from.Disconnect(to);
                    Node = null;
                    return;
                }    
            }
            
            base.OnCreateConnection(@from, to);
        }

        public override void OnRemoveConnection(NodePort port)
        {
            //输入断开,制空
            if (port.IsInput)
            {
                Node = null;
            }
        }
    }
}