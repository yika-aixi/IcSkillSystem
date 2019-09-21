using System.Collections.Generic;
using NPBehave;
using Node = NPBehave.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Composite
{
	[XNode.Node.CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Composite/Sequence")]
	public class SequenceNode : ACompositeNode
	{
		protected override Node GetNode(List<Node> inputNodes)
		{
			return new Sequence(inputNodes.ToArray());
		}
	}
}