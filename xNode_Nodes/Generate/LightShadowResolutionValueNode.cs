using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightShadowResolution Value")]
    public partial class LightShadowResolutionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.LightShadowResolution _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.LightShadowResolution);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}