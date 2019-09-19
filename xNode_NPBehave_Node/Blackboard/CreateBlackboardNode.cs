using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Create")]
    public class CreateBlackboardNode:BlackboardNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        protected ClockNode ClockNode;
        
        public sealed override object GetValue(NodePort port)
        {
            CreateBlackboard();
            return base.GetValue(port);
        }

        protected virtual void CreateBlackboard()
        {
            var clock = GetInputValue(nameof(ClockNode), ClockNode);

            if (clock.Clock != null) 
                Blackboard = new Blackboard(clock.Clock);
        }
    }
}