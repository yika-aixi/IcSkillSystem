using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/ManipulationStartedEventArgs Value")]
    public partial class ManipulationStartedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.ManipulationStartedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.ManipulationStartedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}