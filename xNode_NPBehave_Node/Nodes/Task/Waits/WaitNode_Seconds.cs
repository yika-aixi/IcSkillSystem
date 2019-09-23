using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Seconds")]
    public class WaitNode_Seconds:ANPBehaveNode
    {
        [SerializeField] 
        protected float Seconds;

        protected override void CreateNode()
        {
            Node = new Wait(Seconds);
        }
    }
}