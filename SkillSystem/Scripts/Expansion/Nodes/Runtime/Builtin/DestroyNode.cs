using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Destroy Target")]
    public class DestroyNode:ANPBehaveNode<Action>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private GameObject _target;
            
        protected override Action GetOutValue()
        {
            return  new Action(_destroy);
        }

        private void _destroy()
        {
            var target = GetInputValue(nameof(_target), _target);

            if (target)
            {
                Destroy(target);
            }
        }
    }
}