using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/System object Condition")]
    public class SystemObjectConditionNode:AObservingDecoratorNode<Condition>
    {
        public const string AInputName = "A";
        public const string BInputName = "B";

        [SerializeField]
        private float _checkInterval;

        [SerializeField]
        private float _randomVariance;

        private NodePort _aPort;
        private NodePort _bPort;

        [SerializeField]
        private string _valueTypeAQName;

        protected override Condition GetDecoratorNode()
        {
            _aPort = GetInputPort(AInputName);
            _bPort = GetInputPort(BInputName);
            
            return new Condition(_compared,Stops,_checkInterval,_randomVariance,DecorateeNode);
        }

        private bool _compared()
        {
            if (_aPort == null || _bPort == null)
            {
                return false;
            }

            var aValue = _aPort.GetInputValue();
            var bValue = _aPort.GetInputValue();

            return aValue == bValue;
        }
    }
}