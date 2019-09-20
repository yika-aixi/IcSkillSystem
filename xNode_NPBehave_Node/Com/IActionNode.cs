using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com
{
    public interface IActionNode
    {
    }

    public interface IActionExecuteNode:IActionNode
    {
        void Execute();
    }
    
    public interface ISingleFrameFuncExecuteNode:IActionNode
    {
        bool Execute();
    }
    
    public interface IMultiFrameFuncExecuteNode:IActionNode
    {
        Action.Result Execute(bool arg);
    }
    
    public interface IMultiFrameFunc2ExecuteNode:IActionNode
    {
        Action.Result Execute(Action.Request request);
    }
}