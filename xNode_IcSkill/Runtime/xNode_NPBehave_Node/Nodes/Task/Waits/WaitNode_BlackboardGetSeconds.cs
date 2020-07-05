using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Blackboard Get Seconds")]
    [NodeWidth(300)]
    public class WaitNode_BlackboardGetSeconds:ANPBehaveNode<Wait>
    {
        [SerializeField] 
        private string _blackboardKey;

        [SerializeField] 
        private float _randomVariance;

        protected override Wait CreateOutValue()
        {
            return new Wait(_blackboardKey,_randomVariance);
        }
    }
}