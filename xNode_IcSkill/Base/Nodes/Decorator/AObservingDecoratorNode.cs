//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-23:59
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    public abstract class AObservingDecoratorNode<T>:ADecoratorNode<T> where T : Node
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<Stops> _stops;

        protected Stops Stops => GetInputValue(nameof(_stops), _stops);
    }
}