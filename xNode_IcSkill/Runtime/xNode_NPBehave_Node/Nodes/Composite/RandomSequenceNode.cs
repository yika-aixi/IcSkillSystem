//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-23:07
//Assembly-CSharp

using System.Collections.Generic;
using System.Linq;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Composite
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Composite/Random Sequence")]
    public class RandomSequenceNode:ACompositeNode<RandomSequence>
    {
        protected override RandomSequence GetNode(IEnumerable<Node> inputNodes)
        {
            return new RandomSequence(inputNodes.ToArray());
        }
    }
}