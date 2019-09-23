using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Until Stopped")]
    [NodeWidth(300)]
    public class WaitUntilStoppedNode:ANPBehaveNode
    {
        [SerializeField] 
        private bool _sucessWhenStopped;

        [SerializeField,Output()]
        [PortTooltip("直到完成的等待节点")]
        private WaitUntilStoppedNode _output;
        
        protected override void CreateNode()
        {
            _output = this;
            Node = new WaitUntilStopped(_sucessWhenStopped);
        }
    }
}