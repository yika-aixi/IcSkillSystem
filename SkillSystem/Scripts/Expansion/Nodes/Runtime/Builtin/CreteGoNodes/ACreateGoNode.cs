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
    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Create GameObject")]
    public abstract class CreateGoNode:ANPBehaveNode<Action>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private GameObject _go;
        
        //基于自身坐标
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private bool _basedOnItselfPos = true;
        
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private Vector3 _pos;
        
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private Quaternion _quaternion = Quaternion.identity;

        [Output(ShowBackingValue.Always)]
        private GameObject _instantiates;

        protected GameObject Go => GetInputValue(nameof(_go),_go);

        protected bool BasedOnItselfPos => GetInputValue(nameof(_basedOnItselfPos),_basedOnItselfPos);

        protected Vector3 Pos => GetInputValue(nameof(_pos),_pos);

        protected Quaternion Quaternion => GetInputValue(nameof(_quaternion),_quaternion);
        
        

        protected override Action GetOutValue()
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
            _go = GetInputValue(nameof(_go),_go);

            var pos = GetInputValue(nameof(_pos),_pos);

            if (_basedOnItselfPos)
            {
                pos += SkillGroup.Owner.transform.position;
            }
            
            _quaternion = GetInputValue(nameof(_quaternion),_quaternion);

            _instantiates = Instantiate(_go,pos, _quaternion);
        }
    }
}