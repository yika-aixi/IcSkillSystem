using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShadowProjection Value")]
    public partial class ShadowProjectionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ShadowProjection _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ShadowProjection);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}