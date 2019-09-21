using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;
using XNode;
using Node = NPBehave.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Composite
{
	[XNode.Node.CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Composite/Sequence")]
	public class SequenceNode : NPBehaveNode
	{
		[SerializeField,Input(typeConstraint = TypeConstraint.Inherited)]
		[PortTooltip("节点,可多个")]
		private NPBehaveNode _nodes;

		protected override void CreateNode()
		{
			var nodes = GetInputValue(nameof(_nodes), _nodes);

			if (nodes != null)
			{
				List<Node> inputNodes = new List<Node>();
				foreach (var nodePort in Inputs)
				{
					foreach (var connection in nodePort.GetConnections())
					{
						var node = (NPBehaveNode) connection.node;

						if (node.Node == null)
						{
							continue;
						}

						inputNodes.Add(node.Node);
					}
				}

				if (inputNodes.Count > 0)
				{
					Node = new Sequence(inputNodes.ToArray());
				}
			}
			else
			{
				if (Node != null)
				{
					Node = null;
				}
			}
		}
	}
}