using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/NavigationUpdatedEventArgs Value")]
    public partial class NavigationUpdatedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.NavigationUpdatedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.NavigationUpdatedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}