using System;
using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Clock/Get UnityContext")]
    public class UnityContextClockNode:ClockNode
    {
        protected override Clock GetOutValue()
        {
            return UnityContext.GetClock(); 
        }
    }
}