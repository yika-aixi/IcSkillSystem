using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Until Stopped")]
    public class WaitUntilStoppedNode:ANPBehaveNode
    {
        [SerializeField] 
        private bool _sucessWhenStopped;

        protected override void CreateNode()
        {
            Node = new WaitUntilStopped(_sucessWhenStopped);
        }
    }
}