using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Seconds and Variance")]
    [NodeWidth(300)]
    public class WaitNode_SecondsAndRandomVariance:ANPBehaveNode<Wait>
    {
        [SerializeField] 
        private float _seconds;
        
        [SerializeField] 
        private float _randomVariance;

        protected override Wait GetOutValue()
        {
            return new Wait(_seconds,_randomVariance);
        }
    }
}