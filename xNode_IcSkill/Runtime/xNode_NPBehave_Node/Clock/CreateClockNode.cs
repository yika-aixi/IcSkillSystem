using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Clock/Create")]
    public class CreateClockNode:ClockNode
    {
        private Clock _clock;

        protected override Clock GetOutValue()
        {
            if (_clock == null)
            {
               _clock = new Clock();

               var update = this.SkillGraph.Owner.GetOrAddComponent<ClockUpdate>();
               
               update.AddClock(_clock);
            }
           
            return _clock;
        }
    }
}