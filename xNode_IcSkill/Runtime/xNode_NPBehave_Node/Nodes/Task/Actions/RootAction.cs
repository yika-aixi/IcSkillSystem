using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Root Start Or Stop")]
    public class RootAction:ANPBehaveNode<Action>
    {
        [SerializeField]
        private bool _start;
        
        protected override Action GetOutValue()
        {
            return new Action(multiframeFunc2: request =>
            {
                if (request != Action.Request.START)
                {
                    return Action.Result.SUCCESS;
                }
                
                var root = OutValue.RootNode;
                
                if (_start)
                {
                    root.Start();
                }
                else
                {
                    root.Stop();
                }

                return Action.Result.PROGRESS;
            });
        }
    }
}