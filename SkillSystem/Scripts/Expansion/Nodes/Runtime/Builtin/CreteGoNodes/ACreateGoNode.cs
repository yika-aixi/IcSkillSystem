//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月17日-21:55
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class ACreateGoNode:ANPBehaveNode<Action>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private GameObject _go;
        
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private Quaternion _quaternion = Quaternion.identity;

        [Output(ShowBackingValue.Always)]
        private GameObject _instantiates;

        protected GameObject Go => GetInputValue(nameof(_go),_go);

        protected Quaternion Quaternion => GetInputValue(nameof(_quaternion),_quaternion);
        
        protected sealed override Action GetOutValue()
        {
            return new Action(_create);
        }

        protected override object GetPortValue(NodePort port)
        {
            if (port.fieldName == nameof(_instantiates))
            {
                return _instantiates;
            }

            return null;
        }

        private void _create()
        {
            _instantiates = CreateGo();
        }

        protected abstract GameObject CreateGo();
    }
}