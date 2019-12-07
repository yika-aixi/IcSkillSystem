//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月18日-20:30
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Move/Translate")]
    public class TranslateNode:AMoveNode
    {
        [SerializeField]
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltip("End Pos")]
        private Vector3 _destination;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)] 
        private Space _space = Space.World;

        [SerializeField, Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Inherited)]
        private float _speed = 1;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)] 
        private float _stopDis = 1f;
        
        protected Vector3 Destination => GetInputValue(nameof(_destination), _destination);
   
        protected override Action.Result Move(Action.Request arg)
        {
            return _move(arg);
        }

        private Action.Result _move(Action.Request arg)
        {
            if (arg == Action.Request.CANCEL)
            {
                return CompleteResult;
            }
            
            var dis = GetInputValue(nameof(_stopDis), _stopDis);
            var speed = GetInputValue(nameof(_speed), _speed);
            var space = GetInputValue(nameof(_space), _space);

            var direction = Destination - Tran.position;
            
            if (direction.sqrMagnitude <= dis)
            {
                return CompleteResult;
            }
            
            Tran.Translate(Time.fixedDeltaTime * speed * direction,space);

            return MoveResult;
        }
    }
}