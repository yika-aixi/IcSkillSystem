using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/PropagationPhase Value")]
    public partial class PropagationPhaseValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.PropagationPhase _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.PropagationPhase);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}