using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/test")]
    public class NodeT:NPBehaveNode
    {
        [SerializeField,Output]
        private NodeT _outSequenceNode;
        public override object GetValue(NodePort port)
        {
            _outSequenceNode = (NodeT) base.GetValue(port);
            
            return _outSequenceNode;
        }

        protected override void CreateNode()
        {
            Node = new Action(() => {Debug.LogError("1");});
        }
    }
}