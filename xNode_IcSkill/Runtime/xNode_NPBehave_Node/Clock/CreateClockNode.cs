using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Clock/Create")]
    public class CreateClockNode:ClockNode
    {
        protected override Clock GetOutValue()
        {
           return new Clock();
        }
    }
}