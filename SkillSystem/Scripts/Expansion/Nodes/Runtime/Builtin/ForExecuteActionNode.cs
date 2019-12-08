using System;
using System.Collections;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using XNode;
using Action = NPBehave.Action;
using Node = NPBehave.Node;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/For Execute")]
    public class ForExecuteActionNode:ANPBehaveNode<Action>
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private IEnumerable _enumerables;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Node _action;
        
        [Output(ShowBackingValue.Always)]
        private object _currentValue;
        
        [Output(ShowBackingValue.Always)]
        private int _index;

        private Action _selfAction;
        protected override Action GetOutValue()
        {
            _selfAction = new Action(_for);
            return _selfAction;
        }

        protected override object GetPortValue(NodePort port)
        {
            if (port.fieldName == nameof(_currentValue))
            {
                return _currentValue;
            }
  
            if (port.fieldName == nameof(_index))
            {
                return _index;
            }

            return null;
        }

        private void _for()
        {
            var action = GetInputValue(nameof(_action), _action);
            
            if (action == null)
            {
                return;
            }
            
            var enumerables = GetInputValue(nameof(_enumerables), _enumerables);

            if (enumerables != null)
            {
                var ator = enumerables.GetEnumerator();

                _index = 0;

                if (action.IsActive)
                {
                    action.Stop();
                }
                
                while (ator.MoveNext())
                {
                    _currentValue = ator.Current;
                    if (action.RootNode == null)
                    {
                        action.SetRoot(_selfAction.RootNode);
                    }
                    action.Start();
                    _index++;
                }
            }
        }

        public override void OnCreateConnection(NodePort @from, NodePort to)
        {
            if (to.fieldName == nameof(_enumerables))
            {
                var port = GetPort(nameof(_currentValue));
                
                Type newType = port.ValueType;

                if (from.ValueType.IsArray)
                {
                    newType = from.ValueType.GetElementType();
                }
                else if (from.ValueType.IsGenericType)
                {
                    newType = from.ValueType.GetGenericArguments()[0];
                }

                port.ValueType = newType;
            }
        }
    }
}