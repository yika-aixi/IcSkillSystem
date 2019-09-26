using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/NetworkReachability Value")]
    public partial class NetworkReachabilityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.NetworkReachability _value;

        public override Type ValueType { get; } = typeof(UnityEngine.NetworkReachability);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}