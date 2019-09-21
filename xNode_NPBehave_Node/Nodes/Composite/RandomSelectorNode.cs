//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-23:06
//Assembly-CSharp

using System.Collections.Generic;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Composite
{
    [XNode.Node.CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Composite/Random Selector")]
    public class RandomSelectorNode:ACompositeNode
    {
        protected override Node GetNode(List<Node> inputNodes)
        {
            return new RandomSelector(inputNodes.ToArray());
        }
    }
}