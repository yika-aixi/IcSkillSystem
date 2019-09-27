using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ConnectionTarget Value")]
    public partial class ConnectionTargetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Networking.PlayerConnection.ConnectionTarget _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Networking.PlayerConnection.ConnectionTarget);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}