using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SkinQuality Value")]
    public partial class SkinQualityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SkinQuality _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SkinQuality);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}