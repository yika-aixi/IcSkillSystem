using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    public abstract class ANPBehaveNode<T>:ANPNode<T> where T : Node
    {
        public const string SharedBlackBoard = "SkillSystem.Shared";
        private T _value;
        protected sealed override T GetOutValue()
        {
            if (_value == null)
            {
                _value = CreateOutValue();
            }

#if UNITY_EDITOR
            _value.Label = name.Replace("(Clone)", string.Empty);
            if (_value.Label == _value.Name)
            {
                _value.Label = string.Empty;
            }
#endif
            return _value;
        }
        
        protected abstract T CreateOutValue();
    }
}