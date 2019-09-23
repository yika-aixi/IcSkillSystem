using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Seconds and Variance")]
    public class WaitNode_SecondsAndRandomVariance:WaitNode_Seconds
    {
        [SerializeField] 
        private float _randomVariance;

        protected override void CreateNode()
        {
            Node = new Wait(Seconds,_randomVariance);
        }
    }
}