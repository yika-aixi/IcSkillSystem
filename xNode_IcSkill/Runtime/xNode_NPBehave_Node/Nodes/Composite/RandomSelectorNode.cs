//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-23:06
//Assembly-CSharp

using System.Collections.Generic;
using System.Linq;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Composite
{
    [XNode.Node.CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Composite/Random Selector")]
    public class RandomSelectorNode:ACompositeNode<RandomSelector>
    {
        protected override RandomSelector GetNode(IEnumerable<Node> inputNodes)
        {
            return new RandomSelector(inputNodes.ToArray());
        }
    }
}