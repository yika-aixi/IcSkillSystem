using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Clock/Create")]
    public class CreateClockNode:ClockNode
    {
        protected override void CreateNode()
        {
            base.CreateNode();
            
            Clock = new Clock();
        }
    }
}