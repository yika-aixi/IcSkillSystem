using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/NavigationCompletedEventArgs Value")]
    public partial class NavigationCompletedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.NavigationCompletedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.NavigationCompletedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}