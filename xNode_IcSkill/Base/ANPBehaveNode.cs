using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    public abstract class ANPBehaveNode<T>:ANPNode<T> where T : Node
    {
        private T _value;
        protected sealed override T GetOutValue()
        {
            if (_value == null)
            {
                _value = CreateOutValue();
            }
            
            return _value;
        }
        
        protected abstract T CreateOutValue();
    }
}