using NPBehave;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Move/Set Position")]
    public class SetPositionNode:AMoveNode
    {
        protected override Action GetOutValue()
        {
            return new Action(_setPos);
        }

        private void _setPos()
        {
            Tran.position = Destination;
        }
    }
}