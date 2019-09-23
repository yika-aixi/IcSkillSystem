using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Blackboard Get Seconds")]
    [NodeWidth(300)]
    public class WaitNode_BlackboardGetSeconds:ANPBehaveNode
    {
        [SerializeField] 
        private string _blackboardKey;

        [SerializeField] 
        private float _randomVariance;
        
        [SerializeField,Output()]
        [PortTooltip("黑板获取秒的等待节点")]
        private WaitNode_BlackboardGetSeconds _output;

        protected override void CreateNode()
        {
            _output = this;
            Node = new Wait(_blackboardKey,_randomVariance);
        }
    }
}