using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShadowMapPass Value")]
    public partial class ShadowMapPassValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ShadowMapPass _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ShadowMapPass);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}