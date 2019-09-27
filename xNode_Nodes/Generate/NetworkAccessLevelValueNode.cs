using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/NetworkAccessLevel Value")]
    public partial class NetworkAccessLevelValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.Types.NetworkAccessLevel _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.Types.NetworkAccessLevel);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}