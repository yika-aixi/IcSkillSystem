using System;
using UnityEngine;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Tasks
{
    public abstract class AActionNode<T>:ANPBehaveNode<Action> where T : Delegate
    {
        public static readonly string InputPortName = nameof(Action);
        
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