using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/ConnectionAcksType Value")]
    public partial class ConnectionAcksTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.ConnectionAcksType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.ConnectionAcksType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}