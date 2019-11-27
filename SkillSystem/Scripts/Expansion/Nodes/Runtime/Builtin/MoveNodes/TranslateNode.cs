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
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)] 
        private Action.Result _moveResult = Action.Result.PROGRESS;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)] 
        private Action.Result _completeResult = Action.Result.SUCCESS;

        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)] 
        private Space _space = Space.World;

        [SerializeField, Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Inherited)]
        private float _speed = 1;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)] 
        private float _stopDis = 1f;
        
        protected override Action GetOutValue()
        {
            return new Action(_move);
        }

        private Action.Result _move(Action.Request arg)
        {
            var dis = GetInputValue(nameof(_stopDis), _stopDis);
            var speed = GetInputValue(nameof(_speed), _speed);
            var space = GetInputValue(nameof(_space), _space);
            
            if (arg == Action.Request.CANCEL)
            {
                return GetInputValue(nameof(_completeResult), _completeResult);
            }

            var direction = Destination - Tran.position;
            
            if (direction.sqrMagnitude <= dis)
            {
                return GetInputValue(nameof(_completeResult), _completeResult);
            }
            
            Tran.Translate(Time.fixedDeltaTime * speed * direction,space);

            return GetInputValue(nameof(_moveResult), _moveResult);;
        }
    }
}