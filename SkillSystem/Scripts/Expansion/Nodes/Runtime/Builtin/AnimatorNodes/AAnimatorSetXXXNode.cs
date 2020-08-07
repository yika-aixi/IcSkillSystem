//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月18日-20:59
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NPBehave;
using UnityEngine;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class AAnimatorSetXXXNode:AAnimatorNode
    {
        private static FasterDictionary<string, int> _hashCache = new FasterDictionary<string, int>();

        [Node.InputAttribute(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        [SerializeField]
        private string _name;

        protected string Name => GetInputValue(nameof(_name), _name);

        protected int Hash
        {
            get
            {
                var key = Name;
                
                if (!_hashCache.TryGetValue(key,out var hash))
                {
                    hash = Animator.StringToHash(key);
                    _hashCache.Add(key, hash);
                }

                return hash;
            }
        }

        protected override Task CreateAction()
        {
            return new Action(_setXxx);
        }

        private void _setXxx()
        {
            HashMode(Hash);
        }

        protected abstract void HashMode(in int hash);
    }
}