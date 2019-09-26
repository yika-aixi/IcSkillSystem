using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShadowResolution Value")]
    public partial class ShadowResolutionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ShadowResolution _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ShadowResolution);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}