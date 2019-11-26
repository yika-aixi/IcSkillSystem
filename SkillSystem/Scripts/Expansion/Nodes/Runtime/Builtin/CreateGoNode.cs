//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月17日-21:55
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.Runtime.Nodes;
using NPBehave;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Create GameObject")]
    public class CreateGoNode:ANPBehaveNode<Action>
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
        
        protected override Action GetOutValue()
        {
            return new NPBehave.Action(_create);
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