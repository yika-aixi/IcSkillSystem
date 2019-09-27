using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BatteryStatus Value")]
    public partial class BatteryStatusValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BatteryStatus _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BatteryStatus);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}