using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/NetworkID Value")]
    public partial class NetworkIDValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.Types.NetworkID _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.Types.NetworkID);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}