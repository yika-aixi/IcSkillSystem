using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/SourceID Value")]
    public partial class SourceIDValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.Types.SourceID _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.Types.SourceID);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}