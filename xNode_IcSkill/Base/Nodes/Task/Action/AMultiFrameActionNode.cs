using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks
{
    public abstract class AMultiFrameAction:AActionNode
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)] 
        private Action.Result _executeResult = Action.Result.PROGRESS;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)] 
        private Action.Result _completeResult = Action.Result.SUCCESS;

        protected Action.Result ExecuteResult => GetInputValue(nameof(_executeResult),_executeResult);

        protected Action.Result CompleteResult => GetInputValue(nameof(_completeResult),_completeResult);

        protected sealed override Action GetOutValue()
        {
            return new Action(Execute);
        }

        protected virtual Action.Result Execute(Action.Request arg)
        {
            if (arg == Action.Request.CANCEL)
            {
                return Complete();
            }

            return ExecuteResult;
        }

        protected virtual Action.Result Complete()
        {
            return CompleteResult;
        }
    }
}