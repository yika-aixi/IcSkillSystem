using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShadowmaskMode Value")]
    public partial class ShadowmaskModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ShadowmaskMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ShadowmaskMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}