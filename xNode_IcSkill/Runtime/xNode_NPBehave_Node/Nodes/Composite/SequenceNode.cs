using System.Collections.Generic;
using System.Linq;
using NPBehave;
using Node = NPBehave.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Composite
{
	[XNode.Node.CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Composite/Sequence")]
	public class SequenceNode : ACompositeNode<Sequence>
	{
		protected override Sequence GetNode(IEnumerable<Node> inputNodes)
		{
			return new Sequence(inputNodes.ToArray());
		}
	}
}