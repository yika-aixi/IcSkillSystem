using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/QosType Value")]
    public partial class QosTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.QosType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.QosType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}