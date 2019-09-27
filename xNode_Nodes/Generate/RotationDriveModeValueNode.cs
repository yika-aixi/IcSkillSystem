using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RotationDriveMode Value")]
    public partial class RotationDriveModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RotationDriveMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RotationDriveMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}