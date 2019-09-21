using System;
using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Clock/Get UnityContext")]
    public class UnityContextClockNode:ClockNode
    {
        protected override void CreateNode()
        {
            Clock = UnityContext.GetClock();
            return base.GetValue(port);
        }
    }
}