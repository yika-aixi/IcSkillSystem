using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/AppID Value")]
    public partial class AppIDValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.Types.AppID _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.Types.AppID);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}