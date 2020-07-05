using System;
using UnityEngine;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks
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
        private LogType _type;

        [SerializeField]
        [Label("String Message")]
        public string _simMessage;

        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private object _message;
        
        protected override Action CreateOutValue()
        {
            return new Action(_log);
        }

        private void _log()
        {
            _message = GetInputValue<object>(nameof(_message),_simMessage);
            
            switch (_type)
            {
                case LogType.Error:
                    Debug.LogError(_message);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(_message);
                    break;
                case LogType.Log:
                    Debug.Log(_message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}