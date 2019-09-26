using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ColorGamut Value")]
    public partial class ColorGamutValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ColorGamut _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ColorGamut);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}