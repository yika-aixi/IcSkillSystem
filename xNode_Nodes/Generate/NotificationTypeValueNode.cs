using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/NotificationType Value")]
    public partial class NotificationTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.iOS.NotificationType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.iOS.NotificationType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}