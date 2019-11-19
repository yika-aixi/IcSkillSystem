//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-23:59
//Assembly-CSharp

using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    public abstract class AObservingDecoratorNode<T>:ADecoratorNode<T> where T : Node
    {
        [SerializeField] 
        protected Stops Stops;
    }
}