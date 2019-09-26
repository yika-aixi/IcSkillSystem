using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DeviceGeneration Value")]
    public partial class DeviceGenerationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.iOS.DeviceGeneration _value;

        public override Type ValueType { get; } = typeof(UnityEngine.iOS.DeviceGeneration);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}