//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:33
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class ANPNode<T>:Node where T : ANPNode<T>
    {
        public static readonly string OutputName = nameof(_output);
        public NPBehave.Node Node { get; protected set; }

        [SerializeField,Output(ShowBackingValue.Always)]
        [PortTooltip("自身返回")]
        private T _output;

        public sealed override object GetValue(NodePort port)
        {
            CreateNode();
            _output = (T) this;
            return _output;
        }

        protected abstract void CreateNode();
    }
}