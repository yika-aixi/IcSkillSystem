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
    public interface IActionExecuteNode<in T>:IActionNode
    {
        void Execute(T arg);
    }
    
    /// <summary>
    /// 1个参数 Action
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFuncExecuteNode<out T>:IActionNode
    {
        T Execute();
    }
    
    public interface ISingleFrameFuncExecuteNode:IFuncExecuteNode<bool>
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