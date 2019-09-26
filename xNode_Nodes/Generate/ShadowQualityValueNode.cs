using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShadowQuality Value")]
    public partial class ShadowQualityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ShadowQuality _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ShadowQuality);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}