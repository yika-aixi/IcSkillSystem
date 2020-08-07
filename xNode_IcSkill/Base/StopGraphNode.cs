//Create: Icarus
//ヾ(•ω•`)o
//2020-08-08 01:18
//CabinIcarus.IcSkillSystem.xNodeIc.Base

using CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks;
using NPBehave;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Stop Graph")]
    public class StopGraphNode:AActionNode
    {
        protected override Action CreateOutValue()
        {
            return new Action(_stopGraph);
        }

        private void _stopGraph()
        {
            SkillGraph.StopGroup();
        }
    }
}