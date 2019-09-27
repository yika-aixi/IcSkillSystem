using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MaterialGlobalIlluminationFlags Value")]
    public partial class MaterialGlobalIlluminationFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MaterialGlobalIlluminationFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MaterialGlobalIlluminationFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}