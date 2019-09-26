using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/WindModule/WindZoneMode Value")]
    public partial class WindZoneModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WindZoneMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WindZoneMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}