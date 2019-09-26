using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MessageEventArgs Value")]
    public partial class MessageEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.PlayerConnection.MessageEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.PlayerConnection.MessageEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}