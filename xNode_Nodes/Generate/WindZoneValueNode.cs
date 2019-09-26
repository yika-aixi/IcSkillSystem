using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/WindModule/WindZone Value")]
    public partial class WindZoneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WindZone _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WindZone);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}