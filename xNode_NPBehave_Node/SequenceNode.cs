using NPBehave;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
	[XNode.Node.CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Sequence Node")]
	public class SequenceNode : NPBehaveNode<Sequence>
	{
		// Use this for initialization
		protected override void Init()
		{
			base.Init();
		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			var nodes = port.GetInputValues<NPBehave.Node>();
			
			Node = new Sequence(nodes);

			return this;
		}
	}
}