using System;
using CabinIcarus.IcSkillSystem.Runtime.Nodes;
using CabinIcarus.IcSkillSystem.Runtime.Nodes.Tasks;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [CustomNodeEditorAttribute(typeof(ANPBehaveNode<Action>))]
    public class ActionNodeEditor:ANPNodeEditor<ANPBehaveNode<Action>,Action>
    {
        protected override void ColorCheck()
        {
            var inputPort = target.GetInputPort(AActionNode<Delegate>.InputPortName);
            if (inputPort != null)
            {
                if (!inputPort.IsConnected)
                {
                    Error = true;
                }
            }
        }
    }
}