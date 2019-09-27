using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/InputLegacyModule/LocationInfo Value")]
    public partial class LocationInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LocationInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LocationInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}