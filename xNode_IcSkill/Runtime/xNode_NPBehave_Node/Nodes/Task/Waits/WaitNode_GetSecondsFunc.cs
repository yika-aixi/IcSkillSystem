using System;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/FuncAction Get Seconds")]
    [NodeWidth(300)]
    public class WaitNode_GetSecondsFunc:ANPBehaveNode<Wait>
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Func<float> _getSeconds;

        [SerializeField]
        private float _randomVariance;

        protected override Wait GetOutValue()
        {
            return new Wait(_getSeconds,_randomVariance);
        }
    }
}