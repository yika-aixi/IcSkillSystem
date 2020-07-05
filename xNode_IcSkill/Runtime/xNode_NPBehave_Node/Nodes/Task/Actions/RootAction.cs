using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Root Start Or Stop")]
    public class RootAction:ANPBehaveNode<Action>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltip("no input use self Root of node")]
        private Root _root;
        
        [SerializeField]
        private bool _start;
        
        protected override Action CreateOutValue()
        {
            return new Action(_execute);
        }

        private Action.Result _execute(bool stop)
        {
            if (stop)
            {
                return Action.Result.SUCCESS;
            }
            
            var root = GetInputValue(nameof(_root), OutValue.RootNode);
                            
            if (_start)
            {
                root.Start();
            }
            else
            {
                root.Stop();
            }

            return Action.Result.SUCCESS;
        }
    }
}