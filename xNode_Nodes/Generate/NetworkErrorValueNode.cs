using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/NetworkError Value")]
    public partial class NetworkErrorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.NetworkError _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.NetworkError);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}