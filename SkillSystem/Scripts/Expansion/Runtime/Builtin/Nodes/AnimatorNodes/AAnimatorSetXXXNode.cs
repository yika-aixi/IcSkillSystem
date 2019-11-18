//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月18日-20:59
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using NPBehave;
using UnityEngine;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class AAnimatorSetXXXNode:AAnimatorNode
    {
        //todo 需要editor 进行对应的显示/隐藏
        [Node.InputAttribute(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        [SerializeField]
        private bool _useHash;

        [Node.InputAttribute(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        [SerializeField]
        private string _name;

        [Node.InputAttribute(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        [SerializeField]
        private int _hash;

        protected bool UseHash => GetInputValue(nameof(_useHash),_useHash);

        protected string Name => GetInputValue(nameof(_name), _name);

        protected int Hash => GetInputValue(nameof(_hash), _hash);

        protected override Action CreateAction()
        {
            return new Action(_setXxx);
        }

        private void _setXxx()
        {
            if (UseHash)
            {
                HashMode(Hash);
            }
            else
            {
                NameMode();
            }
        }

        protected abstract void NameMode();

        protected abstract void HashMode(in int hash);
    }
}