//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-22:55
//Assembly-CSharp

using System.Collections.Generic;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Utils
{
    public static class NPBehaveNodeExpansion
    {
        public static void ToNPBehaveNodes(this NPBehaveNode self, List<Node> nodes)
        {
            nodes.Clear();
            
            foreach (var nodePort in self.Inputs)
            {
                foreach (var connection in nodePort.GetConnections())
                {
                    var node = (NPBehaveNode) connection.node;

                    if (node.Node == null)
                    {
                        continue;
                    }

                    nodes.Add(node.Node);
                }
            }
        }
    }
}