using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/UserPresenceState Value")]
    public partial class UserPresenceStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.UserPresenceState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.UserPresenceState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}