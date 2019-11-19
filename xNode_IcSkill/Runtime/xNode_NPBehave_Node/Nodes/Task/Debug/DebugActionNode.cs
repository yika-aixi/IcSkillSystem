using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using UnityEngine;
using Action = NPBehave.Action;

namespace SkillSystem.xNode_IcSkill.Runtime.xNode_NPBehave_Node.Nodes.Task.Debug
{
    public enum LogType
    {
        Log,
        Warning,
        Error
    }
    
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Debug")]
    public class DebugActionNode:ANPBehaveNode<Action>
    {
        [SerializeField]
        public LogType Type;

        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private object _message;
        
        protected override Action GetOutValue()
        {
            return new Action(_log);
        }

        private void _log()
        {
            _message = GetInputValue<object>(nameof(_message));
            
            switch (Type)
            {
                case LogType.Error:
                    UnityEngine.Debug.LogError(_message);
                    break;
                case LogType.Warning:
                    UnityEngine.Debug.LogWarning(_message);
                    break;
                case LogType.Log:
                    UnityEngine.Debug.Log(_message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}