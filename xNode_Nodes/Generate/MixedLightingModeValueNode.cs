using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MixedLightingMode Value")]
    public partial class MixedLightingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MixedLightingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MixedLightingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}