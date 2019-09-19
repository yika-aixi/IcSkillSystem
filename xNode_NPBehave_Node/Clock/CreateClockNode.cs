using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Clock/Create")]
    public class CreateClockNode:ClockNode
    {
        public sealed override object GetValue(NodePort port)
        {
            CreateClock();
            return base.GetValue(port);
        }

        protected virtual void CreateClock()
        {
            if (Clock != null) 
                Clock = new Clock();
        }
    }
}