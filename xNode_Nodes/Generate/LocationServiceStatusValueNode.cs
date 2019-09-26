using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/InputLegacyModule/LocationServiceStatus Value")]
    public partial class LocationServiceStatusValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LocationServiceStatus _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LocationServiceStatus);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}