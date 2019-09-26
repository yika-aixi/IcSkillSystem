using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Slider Value")]
    public partial class SliderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Slider _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Slider);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}