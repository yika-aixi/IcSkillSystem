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
    
    /// <summary>
    /// 1个参数 Action
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IActionExecuteNode<T>:IActionNode
    {
        void Execute(T arg);
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