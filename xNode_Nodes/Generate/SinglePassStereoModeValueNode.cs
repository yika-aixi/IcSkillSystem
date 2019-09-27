using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SinglePassStereoMode Value")]
    public partial class SinglePassStereoModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.SinglePassStereoMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.SinglePassStereoMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}