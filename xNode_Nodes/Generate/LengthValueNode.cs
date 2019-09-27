using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/Length Value")]
    public partial class LengthValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.Length _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.Length);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}