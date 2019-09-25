using System;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    public abstract class AActionNode<T>:ANPBehaveNode<Action> where T : Delegate
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        protected T Action;
        
        protected sealed override Action GetOutValue()
        {
            Action = GetInputValue(nameof(Action), Action);
            
            if (Action == null)
            {
                return null;
            }

            return GetActionNode();
        }

        protected abstract Action GetActionNode();
    }
}