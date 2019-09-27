using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShadowCastingMode Value")]
    public partial class ShadowCastingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ShadowCastingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ShadowCastingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}