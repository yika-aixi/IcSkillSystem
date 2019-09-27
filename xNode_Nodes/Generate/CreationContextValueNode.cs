using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/CreationContext Value")]
    public partial class CreationContextValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.CreationContext _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.CreationContext);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}