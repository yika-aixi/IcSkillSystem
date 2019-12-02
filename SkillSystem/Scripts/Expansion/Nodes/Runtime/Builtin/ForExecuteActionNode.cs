using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using NPBehave;
using XNode;
using Node = NPBehave.Node;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public class ForExecuteActionNode:ANPBehaveNode<Action>
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private IEnumerable<object> _enumerables;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Node _action;
        
        [Output(ShowBackingValue.Always)]
        private object _currentValue;
        
        [Output(ShowBackingValue.Always)]
        private int _index;

        protected override Action GetOutValue()
        {
            return new Action(_for);
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
                while (ator.MoveNext())
                {
                    _currentValue = ator.Current;
                    action.Start();
                    _index++;
                }
            }
        }
    }
}