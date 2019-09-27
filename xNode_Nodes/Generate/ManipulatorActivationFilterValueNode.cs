using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/ManipulatorActivationFilter Value")]
    public partial class ManipulatorActivationFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.ManipulatorActivationFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.ManipulatorActivationFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}