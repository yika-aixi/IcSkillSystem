using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Clock/Create")]
    public class CreateClockNode:ClockNode
    {
        protected override Clock GetOutValue()
        {
           var  clock = new Clock();

           var update = this.SkillGroup.Owner.GetOrAddComponent<ClockUpdate>();
           
           update.AddClock(clock);
           
           return clock;
        }
    }
}