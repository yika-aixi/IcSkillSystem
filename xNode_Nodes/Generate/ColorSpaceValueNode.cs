using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ColorSpace Value")]
    public partial class ColorSpaceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ColorSpace _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ColorSpace);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}