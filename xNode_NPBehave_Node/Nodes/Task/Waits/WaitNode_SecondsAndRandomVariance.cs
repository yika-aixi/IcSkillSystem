using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Seconds and Variance")]
    [NodeWidth(300)]
    public class WaitNode_SecondsAndRandomVariance:ANPBehaveNode
    {
        [SerializeField] 
        private float _seconds;
        
        [SerializeField] 
        private float _randomVariance;

        [SerializeField,Output()]
        [PortTooltip("输入秒及随机偏移的等待节点")]
        private WaitNode_SecondsAndRandomVariance _output;
        
        protected override void CreateNode()
        {
            _output = this;
            Node = new Wait(_seconds,_randomVariance);
        }
    }
}