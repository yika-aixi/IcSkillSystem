using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/NavigationCanceledEventArgs Value")]
    public partial class NavigationCanceledEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.NavigationCanceledEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.NavigationCanceledEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}