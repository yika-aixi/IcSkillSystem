using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/Background Value")]
    public partial class BackgroundValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.Background _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.Background);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}