using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/OperatingSystemFamily Value")]
    public partial class OperatingSystemFamilyValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.OperatingSystemFamily _value;

        public override Type ValueType { get; } = typeof(UnityEngine.OperatingSystemFamily);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}