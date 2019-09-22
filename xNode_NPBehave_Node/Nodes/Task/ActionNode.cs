using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using UnityEngine;
using XNode;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Action")]
    public class ActionNode:ANPBehaveNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited,baseType:typeof(IActionNode))]
        [PortTooltip("动作节点 - IActionNode")]
        private ANPBehaveNode _executeNode;
        
        [SerializeField,Output()]
        [PortTooltip("动作节点 - IActionNode")]
        private ANPBehaveNode _output;

        protected override void CreateNode()
        {
            _output = this;
            
            _executeNode = GetInputValue(nameof(_executeNode), _executeNode);
            
            if (!_executeNode)
            {
                return;
            }
            
            switch (_executeNode)
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
                default:
                    throw new NotSupportedException($"不支持的Action:{_executeNode.GetType()}");
            }
        }

        public override void OnCreateConnection(NodePort @from, NodePort to)
        {
            if (from.node != this)
            {
                if (from.node is IActionExecuteNode ||
                    from.node is ISingleFrameFuncExecuteNode ||
                    from.node is IMultiFrameFuncExecuteNode ||
                    from.node is IMultiFrameFunc2ExecuteNode)
                {
                    return;
                }
                else
                {
                    //不支持的行为,断开连接
                    from.Disconnect(to);
                }
            }            
        }
    }
}