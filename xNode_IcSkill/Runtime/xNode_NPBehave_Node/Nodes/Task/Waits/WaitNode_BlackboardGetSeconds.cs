using CabinIcarus.IcSkillSystem.Runtime.Nodes.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Blackboard Get Seconds")]
    [NodeWidth(300)]
    public class WaitNode_BlackboardGetSeconds:ANPBehaveNode<Wait>
    {
        [SerializeField] 
        private string _blackboardKey;

        [SerializeField] 
        private float _randomVariance;

        protected override Wait GetOutValue()
        {
            return new Wait(_blackboardKey,_randomVariance);
        }
    }
}