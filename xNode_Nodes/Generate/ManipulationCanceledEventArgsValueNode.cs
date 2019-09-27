using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/ManipulationCanceledEventArgs Value")]
    public partial class ManipulationCanceledEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.ManipulationCanceledEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.ManipulationCanceledEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}