using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    [CustomNodeEditor(typeof(ANPBehaveNode<Action>))]
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