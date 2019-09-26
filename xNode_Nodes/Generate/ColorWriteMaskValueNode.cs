using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ColorWriteMask Value")]
    public partial class ColorWriteMaskValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ColorWriteMask _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ColorWriteMask);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}