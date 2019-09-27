using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/ManipulationUpdatedEventArgs Value")]
    public partial class ManipulationUpdatedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.ManipulationUpdatedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.ManipulationUpdatedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}